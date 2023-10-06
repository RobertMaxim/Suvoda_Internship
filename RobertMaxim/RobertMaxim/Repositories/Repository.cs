using RobertMaxim.DataModel;
using RobertMaxim.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobertMaxim
{
    class Repository<T> : IRepository<T>
    {
        protected readonly AppDbContext _appDbContext;
        public Repository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task Add(T entity)
        {
            try
            {
                if (entity == null)
                {
                    Console.WriteLine("Entity shouldn't be null");
                    return;
                }

                await _appDbContext.AddAsync(entity);
                await _appDbContext.SaveChangesAsync();
                return;
            }
            catch
            {
                throw new Exception("Exception met while trying to add an entity to the database.");
            }
        }
    }
}
