using System;
using System.Web.Optimization;

namespace NDDigital.DiarioAcademia.Apresentacao.WebApp
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