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
            for (int i = 0; i < numberOfRows; i++)
            {
                TableRow r = new TableRow();
                TableCell c = new TableCell();

                LiteralControl newsElement = new LiteralControl();
                newsElement.Text += @"<div>
                <b>November 16th, 2020</b><br />
                <div style='display: flex; justify-content: space-around; align-items:center;'>
                    <div style='max-width: 60px;'>
                        <img src='https://logos-download.com/wp-content/uploads/2018/04/Phoenix_Suns_logo_colour.png' style='max-width: 50px;'/><br /><p>Phoenix Suns</p>
                    </div>
                    <h2>112</h2>
                    <div style='margin:10px;'></div>
                    <h2>113</h2>
                    <div style='max-width: 60px;'>
                        <img src='https://logos-download.com/wp-content/uploads/2016/04/Los_Angeles_Lakers_logo_logotype_emblem-700x447.png' style='max-width: 50px;'/><br /><p>Los Angeles Lakers</p>
                    </div>
                </div>
                <p>FINAL SCORE</p>
                <hr />
            </div>";

                c.Controls.Add(newsElement);

                r.Cells.Add(c); // Add this cell to the row.

                SunsSchedule.Rows.Add(r);
            }
        }
    }
}