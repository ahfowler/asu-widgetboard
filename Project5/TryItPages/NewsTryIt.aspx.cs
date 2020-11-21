using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Project5
{
    public partial class NewsTryIt : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            NewsService.ServiceClient newsProxy = new NewsService.ServiceClient();
            var newsList = newsProxy.GetNewsList();
            foreach(string article in newsList)
            {
                newsResults.Text += article;
            }
        }
    }
}