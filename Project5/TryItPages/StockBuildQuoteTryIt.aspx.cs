using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Project5.TryItPages
{
    public partial class StockBuildQuoteTryIt : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        /*

        protected void Button1_Click(object sender, EventArgs e)
        {
            StockBuildAndQuote.ServiceClient proxy = new StockBuildAndQuote.ServiceClient();
            Label1.Text = proxy.stockBuild();

            List<string> stockSymbols = new List<string>();

            if (System.IO.File.Exists(Label1.Text))
            {
                System.IO.StreamReader Textfile = new System.IO.StreamReader(Label1.Text);

                string line = Textfile.ReadLine();

                while (line != null)
                {
                    string[] stockPair = line.Split(',');
                    stockSymbols.Add(stockPair[0]);
                    line = Textfile.ReadLine();
                }

                Textfile.Close();
            }

            foreach (string stockSymbol in stockSymbols)
            {
                DropDownList1.Items.Add(stockSymbol);
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            StockBuildAndQuote.ServiceClient proxy = new StockBuildAndQuote.ServiceClient();
            Label2.Text = proxy.stockQuote(TextBox1.Text, Label1.Text);
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            TextBox1.Text = DropDownList1.Text;
        }

    */
    }
}