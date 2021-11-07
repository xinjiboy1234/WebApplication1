using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;

namespace WebApplication3
{
    public class Global : HttpApplication
    {
        public Global()
        {
            BeginRequest += Global_BeginRequest;
            EndRequest += Global_EndRequest;
            AuthenticateRequest += Global_AuthenticateRequest;
            AuthorizeRequest += Global_AuthorizeRequest;
        }

        private void Global_AuthorizeRequest(object sender, EventArgs e)
        {
            
        }

        private void Global_AuthenticateRequest(object sender, EventArgs e)
        {
            //var token = Request.QueryString["token"];
            //var exceptUrls = new[] { "/Auth/", "/Content/", "/Scripts/" };
            //foreach (var url in exceptUrls)
            //{
            //    if (Request.RawUrl.Contains(url)) return;
            //}

            //if (!string.IsNullOrWhiteSpace(token))
            //{
            //    FormsAuthentication.SetAuthCookie($"{123}|{123}|{token}", false);
            //}
            //else
            //{
            //    var profile = Context.User?.Identity.Name;
            //    var httpClient = new HttpClient();

            //    if (!string.IsNullOrWhiteSpace(profile))
            //    {
            //        var clientToken = profile.Split('|')[2];
            //        var ssoTokenResult = httpClient.GetStringAsync($"http://localhost:8080/sso/tokenvalidation?token={clientToken}").Result;
            //        var ss = "";
            //    }
            //    else
            //    {
            //        Response.Redirect("http://localhost:8080/account/signin");
            //    }
            //}
        }
        private void Global_EndRequest(object sender, EventArgs e)
        {
            var ss = "";
        }

        private void Global_BeginRequest(object sender, EventArgs e)
        {
            var session = Context.Session;
            var ss = "";
        }

        void Application_Start(object sender, EventArgs e)
        {
            // 在应用程序启动时运行的代码
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

    }
}