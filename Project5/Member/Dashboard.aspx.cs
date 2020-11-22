using System;
using System.Collections.Generic;
using System.IO;
using System.Web.UI;
using System.Web.UI.WebControls;
/**********************************************
 *             PROJECT 5 CONTRIBUTION
 * 
 * Dashboard.aspx - Azaria Fowler
 * Stock build/Quote Widget - Azaria Fowler
 * Phoenix Sun's Widget - Azaria Fowler
 * Horoscope Widget - Azaria Fowler
 * 
 *  Weather Widget - Kaitlyn Allen
 * News Widget - Kaitlyn Allen
 * Horoscope Session Storage - Kaitlyn Allen
 **********************************************/
namespace Project5
{
    public partial class About : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Generate stock pairs file - Azaria Fowler.
            StockBuildAndQuote.ServiceClient proxy = new StockBuildAndQuote.ServiceClient();
            string stockPairsFilePath = proxy.stockBuild();

            // Create stock data holder.
            List<string> stocks = new List<string>();

            // Read the stock pairs file (up to the first 10).
            if (File.Exists(stockPairsFilePath))
            {
                // Reads file line by line 
                StreamReader Textfile = new StreamReader(stockPairsFilePath);

                string line = Textfile.ReadLine();

                while (line != null)
                {
                    string[] stockPair = line.Split(',');
                    stocks.Add(stockPair[0]);

                    line = Textfile.ReadLine();
                }

                Textfile.Close();
            }

            // Dynamically create stocks widget - Azaria Fowler
            for (int i = 0; i < stocks.Count; i++)
            {
                TableRow r = new TableRow();
                TableCell c = new TableCell();

                LiteralControl stockElement = new LiteralControl();
                stockElement.Text += @"<div><b>" + stocks[i] +"</b><br/><h3>" + proxy.stockQuote(stocks[i], stockPairsFilePath) + "<h3><hr /></div>";

                c.Controls.Add(stockElement);

                r.Cells.Add(c); // Add this cell to the row.

                Stocks.Rows.Add(r);
            }

            // Dynamically create news widget - Kaitlyn Allen
            NewsService.ServiceClient newsProxy = new NewsService.ServiceClient();
            var newsReport = newsProxy.GetNewsList();
            for (int i = 0; i < newsReport.Length; i++)
            {
                TableRow r = new TableRow();
                TableCell c = new TableCell();

                LiteralControl newsElement = new LiteralControl();
                newsElement.Text += newsReport[i];

                c.Controls.Add(newsElement);

                r.Cells.Add(c);

                News.Rows.Add(r);
            }

            // Dynamically create sun's schedule - Azaria Fowler
            PhoenixSunsSchedule.ServiceClient phoenixSunsProxy = new PhoenixSunsSchedule.ServiceClient();
            List<string> schedule = phoenixSunsProxy.getSchedule();

            for (int i = 0; i < schedule.Count; i++)
            {
                TableRow r = new TableRow();
                TableCell c = new TableCell();

                LiteralControl newsElement = new LiteralControl();
                newsElement.Text += schedule[i];

                c.Controls.Add(newsElement);

                r.Cells.Add(c); // Add this cell to the row.

                SunsSchedule.Rows.Add(r);
            }

            //dynamically build weather widget - Kaitlyn Allen
            WeatherService.ServiceClient weatherProxy = new WeatherService.ServiceClient();
            var weatherForecast = weatherProxy.GetForecast();
            var todayWeather = weatherProxy.TodayForecast(weatherProxy.GetWeatherReport().daily);
            todaysWeather.Text = todayWeather;
            Weather1.Text = weatherForecast[0];
            Weather2.Text = weatherForecast[1];
            Weather3.Text = weatherForecast[2];
            Weather4.Text = weatherForecast[3];
            Weather5.Text = weatherForecast[4];

            
            // Initialize horoscope widget - Azaria Fowler
            DailyHoroscope.ServiceClient horoscopeProxy = new DailyHoroscope.ServiceClient();
            if(Session.Count != 0)
            {
                string indexKey = "horoscopeSession" + Session.Count;
                Horoscope storedReading = (Horoscope)Session[indexKey];
                horoscopeReading.Text = storedReading._Reading;
                horoscopeSign.Text = storedReading._Sign;
                horoscopeImage.ImageUrl = storedReading._Image;
                horoscopeDropDown.SelectedValue = storedReading._Sign;
            }
            else
            {
                    horoscopeReading.Text = horoscopeProxy.getHoroscopeReading("Aries");
                    horoscopeSign.Text = "Aries";
                    horoscopeImage.ImageUrl = horoscopeProxy.getHoroscopeImage("Aries");
            }
        }
            

        
        protected void submitHoroscope_Click(object sender, EventArgs e)
        {
            //zodiac session storage - Kaitlyn Allen
            string num = Convert.ToString(Session.Count + 1);
            DailyHoroscope.ServiceClient horoscopeProxy = new DailyHoroscope.ServiceClient();
            horoscopeReading.Text = horoscopeProxy.getHoroscopeReading(horoscopeDropDown.Text);
            horoscopeSign.Text = horoscopeDropDown.Text;
            horoscopeImage.ImageUrl = horoscopeProxy.getHoroscopeImage(horoscopeDropDown.Text);
            Horoscope userReading = new Horoscope(horoscopeReading.Text, horoscopeSign.Text, horoscopeImage.ImageUrl);
            string horoscopeKey = "horoscopeSession" + num;
            Session[horoscopeKey] = userReading;
        }
    }

    public class Horoscope
    {
        public string _Reading;
        public string _Sign;
        public string _Image;
        public Horoscope(string reading, string sign, string image)
        {
            _Reading = reading;
            _Sign = sign;
            _Image = image;
        }
    }
}