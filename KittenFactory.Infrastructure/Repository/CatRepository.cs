using KittenFactory.Core.Entities;
using KittenFactory.Core.Repositories;
using KittenFactory.Infrastructure.Data;
using KittenFactory.Infrastructure.Repository.Base;
namespace KittenFactory.Infrastructure.Repository
{
    public class CatRepository : Repository<Cat>, ICatRepository
    {
        public CatRepository(KittenFactoryContext dbContext) : base(dbContext)
        {
        }
    }
}
