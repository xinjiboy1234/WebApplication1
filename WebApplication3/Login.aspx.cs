using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication3
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var key = token.Text;
            var urlPrefix = $"http://{Context.Request.Url.Authority}";
            var returnUrl = $"{urlPrefix}{Context.Request.QueryString["returnUrl"]}";
            Context.Response.Redirect($"http://localhost:7000/Home/AuthValidate?returnUrl={returnUrl}&id={key}&urlPrefix={urlPrefix}");
        }

        protected void Unnamed_Click(object sender, EventArgs e)
        {
            //var httpClient = new HttpClient();
            //var key = token.Text;
            ////var request = new HttpRequestMessage(HttpMethod.Get, "http://localhost:5000/api/values");
            ////request.Headers.Add("Authorization", $"Bear {key}");
            ////var result = httpClient.SendAsync(request).Result;

            ////if (result.StatusCode == HttpStatusCode.OK) return;
            //var returnUrl = $"http://{Context.Request.Url.Authority}{Context.Request.QueryString["returnUrl"]}?id={key}";
            //Context.Response.Redirect($"http://localhost:7000/Home/Privacy?returnUrl={returnUrl}");
        }
    }
}