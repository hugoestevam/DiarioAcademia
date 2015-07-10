using Microsoft.Owin;
using NDDigital.DiarioAcademia.WebApi.App_Start;
using Owin;
using System;
using Microsoft.Owin.Cors;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;

[assembly: OwinStartup(typeof(NDDigital.DiarioAcademia.WebApi.Startup))]
namespace NDDigital.DiarioAcademia.WebApi
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            var config = new HttpConfiguration();

            app.UseCors(CorsOptions.AllowAll);

            app.UseWebApi(config);

            OAuthConfig.ConfigureOAuth(app);

            RoutesConfig.Register(config);

            FormattersConfig.Configure(config);

            
        }
 
    }
}
