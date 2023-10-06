using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobertMaxim.Repositories
{
    interface IRepository<T>
    {
        Task Add(T entity);
    }
}
