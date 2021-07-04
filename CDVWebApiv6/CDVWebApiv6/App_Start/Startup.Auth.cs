using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Microsoft.Owin.Security.Google;
using Microsoft.Owin.Security.OAuth;
using Owin;
using CDVWebApiv6.Providers;
using CDVWebApiv6.Models;

namespace CDVWebApiv6
{
    public partial class Startup
    {
        public static OAuthAuthorizationServerOptions OAuthOptions { get; private set; }

        public static string PublicClientId { get; private set; }

        // Aby uzyskać więcej informacji o konfigurowaniu uwierzytelniania, odwiedź stronę https://go.microsoft.com/fwlink/?LinkId=301864
        public void ConfigureAuth(IAppBuilder app)
        {
            // Skonfiguruj kontekst bazy danych i menedżera użytkowników, aby użyć jednego wystąpienia na żądanie
            app.CreatePerOwinContext(ApplicationDbContext.Create);
            app.CreatePerOwinContext<ApplicationUserManager>(ApplicationUserManager.Create);

            // Zezwalaj aplikacji na przechowywanie w pliku cookie informacji o zalogowanym użytkowniku
            // oraz na tymczasowe przechowywanie w pliku cookie informacji o użytkowniku logującym się przy użyciu dostawcy logowania innego producenta
            app.UseCookieAuthentication(new CookieAuthenticationOptions());
            app.UseExternalSignInCookie(DefaultAuthenticationTypes.ExternalCookie);

            // Skonfiguruj aplikację dla przepływu OAuth
            PublicClientId = "self";
            OAuthOptions = new OAuthAuthorizationServerOptions
            {
                TokenEndpointPath = new PathString("/Token"),
                Provider = new ApplicationOAuthProvider(PublicClientId),
                AuthorizeEndpointPath = new PathString("/api/Account/ExternalLogin"),
                AccessTokenExpireTimeSpan = TimeSpan.FromDays(14),
                // W trybie produkcji ustaw wartość AllowInsecureHttp = false
                AllowInsecureHttp = true
            };

            // Zezwalaj aplikacji na uwierzytelnianie użytkowników za pomocą tokenów bearer
            app.UseOAuthBearerTokens(OAuthOptions);

            // Usuń znaczniki komentarza z poniższych wierszy, aby włączyć logowanie przy użyciu innych dostawców logowania
            //app.UseMicrosoftAccountAuthentication(
            //    clientId: "",
            //    clientSecret: "");

            //app.UseTwitterAuthentication(
            //    consumerKey: "",
            //    consumerSecret: "");

            //app.UseFacebookAuthentication(
            //    appId: "",
            //    appSecret: "");

            //app.UseGoogleAuthentication(new GoogleOAuth2AuthenticationOptions()
            //{
            //    ClientId = "",
            //    ClientSecret = ""
            //});
        }
    }
}
