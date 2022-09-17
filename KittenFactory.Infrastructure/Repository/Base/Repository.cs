using KittenFactory.Core.Entities.Base;
using KittenFactory.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KittenFactory.Infrastructure.Repository.Base
{
    public class Repository<T>: IRepository<T>  where T : Entity
    {
        protected readonly KittenFactoryContext dbContext;

        public Repository(KittenFactoryContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await dbContext.Set<T>().ToListAsync();
        }
        public async Task<T> GetByIdAsync(int id)
        {
            var result =  await dbContext.Set<T>().FindAsync(id);
            if (result == null)
            {
                return Activator.CreateInstance<T>();
            }
            return result;
        }

        public async Task DeleteByIdAsync(int id)
        {
            var obj = await GetByIdAsync(id);
            dbContext.Remove(obj);
            await dbContext.SaveChangesAsync();

        }
        public async Task<T> SaveAsync(T entity)
        {
            try
            {
                if (entity.Id<=0)
                {
                    entity.Id = 0;
                    await dbContext.AddAsync(entity);
                }
                else
                {
                    dbContext.Entry(entity).State = EntityState.Modified;
                }
                await dbContext.SaveChangesAsync();
                return entity;
            }
            catch (Exception e)
            {

                throw;
            }
          
        }
    }
}
