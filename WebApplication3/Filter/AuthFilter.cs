using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
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
        }

        private void Application_BeginRequest(object sender, EventArgs e)
        {
            HttpApplication application = (HttpApplication)sender;
            HttpContext context = application.Context;
            HttpSessionState session = context.Session;
            HttpRequest request = context.Request;
            HttpResponse response = context.Response;
            String contextPath = request.ApplicationPath;
            var rawUrl = request.RawUrl;
            if (rawUrl.Contains("/admin/Sys/SysDictTypeEdit.aspx") && rawUrl.Contains("_method=Save"))
            {
                System.Diagnostics.Debug.WriteLine("begin request");
            }

        }

        private void Application_Error(object sender, EventArgs e)
        {
            HttpApplication application = (HttpApplication)sender;
            HttpContext context = application.Context;
            HttpSessionState session = context.Session;
            HttpRequest request = context.Request;
            HttpResponse response = context.Response;
            String contextPath = request.ApplicationPath;
            var rawUrl = request.RawUrl;
            if (rawUrl.Contains("/admin/Sys/SysDictTypeEdit.aspx") && rawUrl.Contains("_method=Save"))
            {
                System.Diagnostics.Debug.WriteLine("error");
            }
        }

        private void Application_EndRequest(object sender, EventArgs e)
        {
            HttpApplication application = (HttpApplication)sender;
            HttpContext context = application.Context;
            HttpSessionState session = context.Session;
            HttpRequest request = context.Request;
            HttpResponse response = context.Response;
            String contextPath = request.ApplicationPath;
            var rawUrl = request.RawUrl;
            if (rawUrl.Contains("/admin/Sys/SysDictTypeEdit.aspx") && rawUrl.Contains("_method=Save"))
            {
                System.Diagnostics.Debug.WriteLine("end request");
            }
        }

        private void Application_AcquireRequestState(Object source, EventArgs e)
        {
            try
            {
                HttpApplication application = (HttpApplication)source;
                HttpContext context = application.Context;
                HttpSessionState session = context.Session;
                HttpRequest request = context.Request;
                HttpResponse response = context.Response;
                String contextPath = request.ApplicationPath;
                if (application.Context.Handler is System.Web.UI.TemplateControl)
                {
                    var path = ((System.Web.UI.TemplateControl)application.Context.Handler).AppRelativeVirtualPath;
                    if (path == "~/admin/Sys/SysDictTypeEdit.aspx" && request["_method"] == "Save")
                    {
                        Action action = () => System.Diagnostics.Debug.WriteLine("Save777");
                        //注意可以在这里往上下文的IDcitionary里放委托，将来可用于回调（可理解为注册）
                        context.Items.Add(request["_method"], action);
                    }
                }
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public void Dispose() { }
    }
}