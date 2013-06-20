using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LumiSoft.Net;
using LumiSoft.Net.AUTH;
using LumiSoft.Net.IMAP.Client;
using Microsoft.Web.WebPages.OAuth;


namespace TestOauth.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Message = "Modify this template to jump-start your ASP.NET MVC application.";

            return View();
        }

        public ActionResult About()
        {
            
            AUTH_Gmail_OAuth1_3leg oAuth = new AUTH_Gmail_OAuth1_3leg();
            // Create gmail access request.
            oAuth.GetRequestToken();
            // Get authorization URL, let user login to gmail and get verification code.
            System.Diagnostics.Process.Start(oAuth.GetAuthorizationUrl());
            Console.WriteLine("Enter(menu->Paste) gmail verification code:");
            // Get access token which is needed for accessing gmail API.
            oAuth.GetAccessToken(Console.ReadLine().Trim());            

            using (IMAP_Client imap = new IMAP_Client())
            {
                imap.Logger = new LumiSoft.Net.Log.Logger();
                imap.Logger.WriteLog += delegate(object sender, LumiSoft.Net.Log.WriteLogEventArgs e)
                {
                    Console.WriteLine("log: " + e.LogEntry.Text);
                };
                //imap.Connect("imap.gmail.com", WellKnownPorts.IMAP4_SSL, true);                
                imap.Connect("imap.gmail.com", WellKnownPorts.IMAP4, false);
                                

                string email = oAuth.GetUserEmail();
                imap.Authenticate(new AUTH_SASL_Client_XOAuth(email, oAuth.GetXOAuthStringForImap(email)));
                imap.SelectFolder("inbox");

                Console.WriteLine("\r\n\r\n----- You are connected now. Press enter for exit.");
                Console.ReadLine();                
            }



            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
