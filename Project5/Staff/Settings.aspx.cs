using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace Project5
{
    public partial class Contact : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void save_Click(object sender, EventArgs e)
        {
            if (!viewNews.Checked)
            {
                viewNews.Checked = false;
                var t = Page.FindControl("NewsSection");
                HtmlGenericControl newsElement = (HtmlGenericControl)Page.PreviousPage.FindControl("NewsSection");
                newsElement.Visible = false;
                t.Visible = false;
            }
        }
    }
}