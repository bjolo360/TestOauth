using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DotNetOpenAuth.GoogleOAuth2;
using Microsoft.Web.WebPages.OAuth;
using TestOauth.Models;

namespace TestOauth
{
    public static class AuthConfig
    {
        public static void RegisterAuth()
        {
            // To let users of this site log in using their accounts from other sites such as Microsoft, Facebook, and Twitter,
            // you must update this site. For more information visit http://go.microsoft.com/fwlink/?LinkID=252166

            //OAuthWebSecurity.RegisterMicrosoftClient(
            //    clientId: "",
            //    clientSecret: "");

            //OAuthWebSecurity.RegisterTwitterClient(
            //    consumerKey: "",
            //    consumerSecret: "");

            //OAuthWebSecurity.RegisterFacebookClient(
            //    appId: "",
            //    appSecret: "");

            var client = new GoogleOAuth2Client("1082044350279.apps.googleusercontent.com", "vVT5cAMHKES56aaE0keNBhOA");
            var extraData = new Dictionary<string, object>();
            OAuthWebSecurity.RegisterClient(client, "Google", extraData);

            //OAuthWebSecurity.RegisterGoogleClient();
        }
    }
}
