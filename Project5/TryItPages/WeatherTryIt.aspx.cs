using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Project5
{
    public partial class WeatherTryIt : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            WeatherService.ServiceClient weatherProxy = new WeatherService.ServiceClient();
            var weatherForecast = weatherProxy.GetForecast();

            foreach(string day in weatherForecast)
            {
                weatherResults.Text += day;
            }
        }
    }
}