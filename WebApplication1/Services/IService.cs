using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication1.Services
{
    public interface IService<T>
    {
        void Add(T t);
    }
}
