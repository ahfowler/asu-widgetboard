using System;
using System.Collections.Generic;
using System.IO;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Project5
{
    public partial class About : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Generate stock pairs file.
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

            // Dynamically create stocks widget
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

            // Dynamically create news widget
            int numberOfRows = 5;
            for (int i = 0; i < numberOfRows; i++)
            {
                TableRow r = new TableRow();
                TableCell c = new TableCell();

                LiteralControl newsElement = new LiteralControl();
                newsElement.Text += @"<div><b>" + "November 16th, 2020 | 02:54:37" + "</b><br/><h4>" + "Cal football: As clock ticks, Bears still waiting to see if Arizona State game is on" + " </h4><br /><p>" + "Cal officials stay silent as the possibility of a second canceled game looms; ASU, meanwhile, cancels its practice..." + "<a href=" + "https://www.mercurynews.com/2020/11/12/cal-football-as-clock-ticks-bears-still-waiting-to-see-if-arizona-state-game-is-on/" + "> Read More </a>" + "</p><hr /></div>";

                c.Controls.Add(newsElement);

                r.Cells.Add(c); // Add this cell to the row.

                News.Rows.Add(r);
            }

            // Dynamically create sun's schedule
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

            //create weather widget
            WeatherService.ServiceClient weatherProxy = new WeatherService.ServiceClient();
            var weatherForecast = weatherProxy.GetForecast();
            var todayWeather = weatherProxy.TodayForecast(weatherProxy.GetWeatherReport().daily);
            todaysWeather.Text = todayWeather;
            /*for(int i = 0; i < 5; i++)
            {
                TableRow r = new TableRow();
                TableCell c = new TableCell();
                LiteralControl dailyReport = new LiteralControl();
                dailyReport.Text += weatherForecast[i];
                c.Controls.Add(dailyReport);
                r.Cells.Add(c);

                //Weather.Rows.Add(r);
                Weather[i].Text += dailyReport.Text;
                
            }*/
            Weather1.Text = weatherForecast[0];
            Weather2.Text = weatherForecast[1];
            Weather3.Text = weatherForecast[2];
            Weather4.Text = weatherForecast[3];
            Weather5.Text = weatherForecast[4];

            // Initialize horoscope widget
            DailyHoroscope.ServiceClient horoscopeProxy = new DailyHoroscope.ServiceClient();
            horoscopeReading.Text = horoscopeProxy.getHoroscopeReading("Aries");
            horoscopeSign.Text = "Aries";
            horoscopeImage.ImageUrl = horoscopeProxy.getHoroscopeImage("Aries");
        }

        protected void submitHoroscope_Click(object sender, EventArgs e)
        {
            DailyHoroscope.ServiceClient horoscopeProxy = new DailyHoroscope.ServiceClient();
            horoscopeReading.Text = horoscopeProxy.getHoroscopeReading(horoscopeDropDown.Text);
            horoscopeSign.Text = horoscopeDropDown.Text;
            horoscopeImage.ImageUrl = horoscopeProxy.getHoroscopeImage(horoscopeDropDown.Text);
        }
    }
}