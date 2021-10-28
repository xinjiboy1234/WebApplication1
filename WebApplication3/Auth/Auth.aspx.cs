using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication3.Auth
{
    public partial class Auth : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            FormsAuthentication.SetAuthCookie("asdf", false);
            Response.Redirect(Request.QueryString["returnUrl"]);
        }
    }
}