using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;
using System.Web.Security;
using System.Web.SessionState;

namespace WebApp
{
    public class Global : System.Web.HttpApplication
    {
        protected void Application_Start(object sender, EventArgs e)
        {
            var cssBundle = new StyleBundle("~/default/css");

            BundleTable.EnableOptimizations = true;

            cssBundle.IncludeDirectory("~/content/", "*.css", true);

            BundleTable.Bundles.Add(cssBundle);

        }
    }
}