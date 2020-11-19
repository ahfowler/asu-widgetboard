using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Project5
{
    public partial class SiteMaster : MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Global.signedIn)
            {
                signedInPanel.Visible = true;
                logInPanel.Visible = false;
            } else
            {
                signedInPanel.Visible = false;
                logInPanel.Visible = true;
            }
        }

        protected void signOut_Click(object sender, EventArgs e)
        {
            System.Web.Security.FormsAuthentication.SignOut();
            signedInPanel.Visible = false;
            logInPanel.Visible = true;
            Global.signedIn = false;
            Server.Transfer("~/Default.aspx");
        }
    }
}