using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Web;

// NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service" in code, svc and config file together.
public class Service : IService
{
    public string getHoroscopeReading(string sign)
    {
        string destPath = HttpContext.Current.Server.MapPath(@"~/App_Data/HoroscopeReadings.txt");

        if (File.Exists(destPath))
        {
            // Reads file line by line 
            StreamReader Textfile = new StreamReader(destPath);

            string line = Textfile.ReadLine();

            while (line != null)
            {
                string[] horoscopeReading = line.Split(':');
                if (horoscopeReading[0] == sign)
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
            return "The horoscope readings file was not found.";
        }
    }

    public string getHoroscopeImage(string sign)
    {
        string destPath = HttpContext.Current.Server.MapPath(@"~/App_Data/HoroscopeImages.txt");

        if (File.Exists(destPath))
        {
            // Reads file line by line 
            StreamReader Textfile = new StreamReader(destPath);

            string line = Textfile.ReadLine();

            while (line != null)
            {
                string[] horoscopeReading = line.Split(';');
                if (horoscopeReading[0] == sign)
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
