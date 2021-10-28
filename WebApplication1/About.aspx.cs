using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebApplication1.Services;

namespace WebApplication1
{
    public partial class About : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack) return;
            //var ss = new test_db_01Entities();
            //var result = from u in ss.sys_user.AsQueryable<sys_user>()
            //             join d in ss.t_test_table_01.AsQueryable<t_test_table_01>()
            //             on u.Id equals d.ID
            //             select u;
            var orderService = GetInstance<sys_user>();
            orderService.Add(new sys_user 
            {
                password="123",
                username="f1"
            });
            Response.Write(HttpContext.Current.User.Identity.Name);
        }

        private IService<T> GetInstance<T>()
        {
            var type = Type.GetType("WebApplication1.Services.OrderService");
            var obj = Activator.CreateInstance(type, true);
            return (IService<T>)obj;
        }
    }
}