using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Project5
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void ViewStudentsXml(object sender, EventArgs e)
        {
            Response.Clear();
            //returnButton.Visible = true;
            Response.Buffer = true;
            Response.Charset = "";
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.ContentType = "application/xml";
            Response.WriteFile(Server.MapPath(@"~/App_Data/Students.xml"));
            Response.Flush();
            Response.End();
        }

        protected void ViewAdminXml(object sender, EventArgs e)
        {
            Response.Clear();
            //returnButton.Visible = true;
            Response.Buffer = true;
            Response.Charset = "";
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.ContentType = "application/xml";
            Response.WriteFile(Server.MapPath(@"~/App_Data/Administrators.xml"));
            Response.Flush();
            Response.End();
        }
    }
}