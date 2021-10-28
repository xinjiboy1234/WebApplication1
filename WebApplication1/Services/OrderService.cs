using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Services
{
    public class OrderService : IService<sys_user>
    {
        private readonly test_db_01Entities entities = new test_db_01Entities();
        public void Add(sys_user t)
        {
            entities.sys_user.Add(t);
            entities.SaveChanges();
        }
    }

}