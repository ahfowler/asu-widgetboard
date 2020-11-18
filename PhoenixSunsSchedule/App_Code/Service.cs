using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

public class Service : IService
{
    public class HomeTeam
    {
        public int id { get; set; }
        public string abbreviation { get; set; }
        public string city { get; set; }
        public string conference { get; set; }
        public string division { get; set; }
        public string full_name { get; set; }
        public string name { get; set; }
    }

    public class VisitorTeam
    {
        public int id { get; set; }
        public string abbreviation { get; set; }
        public string city { get; set; }
        public string conference { get; set; }
        public string division { get; set; }
        public string full_name { get; set; }
        public string name { get; set; }
    }

    public class Datum
    {
        public int id { get; set; }
        public DateTime date { get; set; }
        public int home_team_score { get; set; }
        public int visitor_team_score { get; set; }
        public int season { get; set; }
        public int period { get; set; }
        public string status { get; set; }
        public string time { get; set; }
        public bool postseason { get; set; }
        public HomeTeam home_team { get; set; }
        public VisitorTeam visitor_team { get; set; }
    }

    public class Meta
    {
        public int total_pages { get; set; }
        public int current_page { get; set; }
        public int next_page { get; set; }
        public int per_page { get; set; }
        public int total_count { get; set; }
    }

    public class Root
    {
        public List<Datum> data { get; set; }
        public Meta meta { get; set; }

        public string getTeamLogo(string teamName)
        {
            string destPath = System.Web.HttpContext.Current.Server.MapPath(@"~/App_Data/NBALogos.txt");

            if (File.Exists(destPath))
            {
                // Reads file line by line 
                StreamReader Textfile = new StreamReader(destPath);

                string line = Textfile.ReadLine();

                while (line != null)
                {
                    string[] horoscopeReading = line.Split(';');
                    if (horoscopeReading[0] == teamName)
                    {
                        Textfile.Close();
                        return horoscopeReading[1].Trim();
                    }
                    else
                    {
                        line = Textfile.ReadLine();
                    }
                }

                Textfile.Close();

                return "The given horoscope symbol was not found.";
            }
            else
            {
                return "The horoscope images file was not found.";
            }
        }
    }

    public List<string> getSchedule()
    {
        List<string> teams = new List<string>();
        string getExchangeRate = @"https://free-nba.p.rapidapi.com/games?page=0&team_ids[]=24&per_page=25";

        Root myDeserializedClass = null;

        HttpWebRequest request = (HttpWebRequest)WebRequest.Create(getExchangeRate);
        request.Headers.Add("X-RapidAPI-Host", "free-nba.p.rapidapi.com");
        request.Headers.Add("X-RapidAPI-Key", "d18e4b34c2mshf5efe2504adcb1bp10699fjsn65b3dfb3c5a7");
        request.AutomaticDecompression = DecompressionMethods.GZip;

        using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
        using (Stream stream = response.GetResponseStream())
        using (StreamReader reader = new StreamReader(stream))
        {
            myDeserializedClass = Newtonsoft.Json.JsonConvert.DeserializeObject<Root>(reader.ReadToEnd());
        }

        for (int i = 0; i < myDeserializedClass.data.Count; i++)
        {
            /*string game = "Home: " + myDeserializedClass.data[i].home_team.name + " Score: " + myDeserializedClass.data[i].home_team_score + "<br/>";
            game += "Away: " + myDeserializedClass.data[i].visitor_team.name + " Score: " + myDeserializedClass.data[i].visitor_team_score + "<br/>";
            game += "Date: " + myDeserializedClass.data[i].date + "<br/>";
            game += "Season: " + myDeserializedClass.data[i].season + "<br/>";*/

            string game = @"<div>
                <b>" + myDeserializedClass.data[i].date.ToString("dddd <br /> MMMM dd, yyyy") + "</b><br />" +
                "<div style='display: flex; justify-content: space-around; align-items:center;'>" +
                    "<div style='max-width: 60px;'>" +
                        "<img src='" + myDeserializedClass.getTeamLogo(myDeserializedClass.data[i].home_team.name) + "' style='width: 50px;'/><br /><p>" + myDeserializedClass.data[i].home_team.name + "</p>" +
                    "</div>" +
                    "<h2>" + myDeserializedClass.data[i].home_team_score + "</h2>" +
                    "<div style='margin:10px;'></div>" +
                    "<h2>" + myDeserializedClass.data[i].visitor_team_score + "</h2>" +
                    "<div style='max-width: 60px;'>" +
                        "<img src='" + myDeserializedClass.getTeamLogo(myDeserializedClass.data[i].visitor_team.name) + "' style='width: 50px;'/><br /><p>" + myDeserializedClass.data[i].visitor_team.name + "</p>" +
                    "</div>" +
                "</div>" +
                "<p>FINAL SCORE</p>" +
                "<hr />" +
            "</div>";

            teams.Add(game);
        }

        return teams;
    }
}
