using Microsoft.Owin;
using Microsoft.Owin.Security.OAuth;
using NDDigital.DiarioAcademia.WebApi.Providers;
using Owin;
using System;

namespace NDDigital.DiarioAcademia.WebApi.App_Start
{
    public static class OAuthConfig
    {
        public static OAuthBearerAuthenticationOptions OAuthBearerOptions { get; private set; }

        public static void ConfigureOAuth(IAppBuilder app)
        {
            var oAuthServerOptions = new OAuthAuthorizationServerOptions
            {
                AllowInsecureHttp = true,
                TokenEndpointPath = new PathString("/token"),
                AccessTokenExpireTimeSpan = TimeSpan.FromDays(30),
                Provider = new SimpleAuthorizationServerProvider()
            };

            //Token Generation

            app.UseOAuthAuthorizationServer(oAuthServerOptions);

            app.UseOAuthBearerAuthentication(new OAuthBearerAuthenticationOptions());
        }
    }
}