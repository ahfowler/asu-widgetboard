﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;

namespace Project5
{
    public class Global : HttpApplication
    {
        public static bool signedIn = false;

        void Application_Start(object sender, EventArgs e)
        {
            // Code that runs on application startup
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        void Application_AuthenticateRequest(object sender, EventArgs e)
        {
            if (Context.User != null)
            {
                if (Context.User.Identity.IsAuthenticated)
                {
                    signedIn = true;
                }
            }
            else
            {
                signedIn = false;
            }
        }
    }
}