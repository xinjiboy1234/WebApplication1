﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;

namespace WebApplication1.Services
{
    /// <summary>
    /// Signout 的摘要说明
    /// </summary>
    public class Signout : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            FormsAuthentication.SignOut();
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}