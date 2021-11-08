using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Configuration;
using System.Web.Security;
using System.Web.SessionState;

namespace WebApplication3.Filter
{
    public class AuthFilter : IHttpModule
    {
        public void Init(HttpApplication application)
        {

            application.BeginRequest += Application_BeginRequest;
            application.Error += Application_Error;
            application.AcquireRequestState += new EventHandler(Application_AcquireRequestState);
            application.EndRequest += Application_EndRequest;
            application.AuthenticateRequest += Application_AuthenticateRequest;
        }

        private void Application_AuthenticateRequest(object sender, EventArgs e)
        {
            HttpApplication application = (HttpApplication)sender;
            HttpContext context = application.Context;
            HttpSessionState session = context.Session;
            HttpRequest request = context.Request;
            HttpResponse response = context.Response;
            String contextPath = request.ApplicationPath;
            var token = request.QueryString["token"];

            if (!string.IsNullOrWhiteSpace(token))
            {
                FormsAuthentication.SetAuthCookie($"{123}|{123}|{token}", false);
                response.Redirect(request.Path);
            }
            else
            {
                var profile = context.User?.Identity.Name;
                var httpClient = new HttpClient();

                if (!string.IsNullOrWhiteSpace(profile))
                {
                    var clientToken = profile.Split('|')[2];
                    var ssoTokenResult = httpClient.GetStringAsync($"http://localhost:8080/sso/tokenvalidation?token={clientToken}").Result;
                    if (string.IsNullOrWhiteSpace(ssoTokenResult))
                    {
                        FormsAuthentication.SignOut();
                    }
                    var tokenModel = JsonConvert.DeserializeObject<TokenReceiveModel<string>>(ssoTokenResult);
                    if (tokenModel.Code != 100000)
                    {
                        FormsAuthentication.SignOut();
                        response.Redirect("/");
                    }
                }
            }
        }

        private void Application_BeginRequest(object sender, EventArgs e)
        {
            HttpApplication application = (HttpApplication)sender;
            HttpContext context = application.Context;
            HttpSessionState session = context.Session;
            HttpRequest request = context.Request;
            HttpResponse response = context.Response;
            String contextPath = request.ApplicationPath;
            //var token = request.QueryString["token"];
            //var exceptUrls = new[] { "/Auth/", "/Content/","/Scripts/" };
            //foreach (var url in exceptUrls)
            //{
            //    if (request.RawUrl.Contains(url)) return;
            //}
            
            //if (!string.IsNullOrWhiteSpace(token))
            //{
            //    FormsAuthentication.SetAuthCookie($"{123}|{123}|{token}", false);
            //}
            //else
            //{
            //    var profile = context.User?.Identity.Name;
            //    var httpClient = new HttpClient();

            //    if (!string.IsNullOrWhiteSpace(profile))
            //    {
            //        var clientToken = profile.Split('|')[2];
            //        var ssoTokenResult = httpClient.GetStringAsync($"http://localhost:8080/sso/tokenvalidation?token={clientToken}").Result;
            //        var ss = "";
            //    }
            //    else
            //    {
            //        response.Redirect("http://localhost:8080/account/signin");
            //    }
            //}
            var rawUrl = request.RawUrl;
            if (rawUrl.Contains("/admin/Sys/SysDictTypeEdit.aspx") && rawUrl.Contains("_method=Save"))
            {
                System.Diagnostics.Debug.WriteLine("begin request");
            }
        }

        private void Application_Error(object sender, EventArgs e)
        {
            //HttpApplication application = (HttpApplication)sender;
            //HttpContext context = application.Context;
            //HttpSessionState session = context.Session;
            //HttpRequest request = context.Request;
            //HttpResponse response = context.Response;
            //String contextPath = request.ApplicationPath;
            //var rawUrl = request.RawUrl;
            //if (rawUrl.Contains("/admin/Sys/SysDictTypeEdit.aspx") && rawUrl.Contains("_method=Save"))
            //{
            //    System.Diagnostics.Debug.WriteLine("error");
            //}
        }

        private void Application_EndRequest(object sender, EventArgs e)
        {
            HttpApplication application = (HttpApplication)sender;
            HttpContext context = application.Context;
            HttpSessionState session = context.Session;
            HttpRequest request = context.Request;
            HttpResponse response = context.Response;
            String contextPath = request.ApplicationPath;
            //var rawUrl = request.RawUrl;
            //if (rawUrl.Contains("/admin/Sys/SysDictTypeEdit.aspx") && rawUrl.Contains("_method=Save"))
            //{
            //    System.Diagnostics.Debug.WriteLine("end request");
            //}

            if (context.Request.IsAuthenticated)
            {
                var ss = "";
            }
        }

        private void Application_AcquireRequestState(object source, EventArgs e)
        {
            try
            {
                var application = (HttpApplication)source;
                var context = application.Context;
                var session = context.Session;
                var request = context.Request;
                var response = context.Response;
                var contextPath = request.ApplicationPath;
                // 如果不需要登录，直接跳转到目标网址

                var httpClient = new HttpClient();
                var token = request.QueryString["token"];

                #region 校验token



                #endregion

                //var sessionToken = session["token"]?.ToString();
                //if (!string.IsNullOrWhiteSpace(token))
                //{
                //    session["token"] = token;
                //}
                //else
                //{
                //    if (!string.IsNullOrWhiteSpace(sessionToken))
                //    {
                //        var ssoTokenResult = httpClient.GetStringAsync($"http://localhost:8080/sso/tokenvalidation?token={sessionToken}").Result;
                //        var ss = "";
                //    }
                //    else
                //    {
                //        response.Redirect("http://localhost:8080/account/signin");
                //    }
                //}
                
                
               
                //if (application.Context.Handler is System.Web.UI.TemplateControl)
                //{
                //    var path = ((System.Web.UI.TemplateControl)application.Context.Handler).AppRelativeVirtualPath;
                //    if (path == "~/admin/Sys/SysDictTypeEdit.aspx" && request["_method"] == "Save")
                //    {
                //        Action action = () => System.Diagnostics.Debug.WriteLine("Save777");
                //        //注意可以在这里往上下文的IDcitionary里放委托，将来可用于回调（可理解为注册）
                //        context.Items.Add(request["_method"], action);
                //    }
                //}
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public void Dispose() { }
    }

    class TokenReceiveModel<T> 
    {
        public int? Code { get; set; }
        public string Message { get; set; }
        public T Data { get; set; }
    }
}