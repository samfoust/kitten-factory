using KittenFactory.Core.Entities.Base;

namespace KittenFactory.Infrastructure.Repository.Base
{
    public interface IRepository<T> where T : Entity
    {
        Task DeleteByIdAsync(int id);
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetByIdAsync(int id);
        Task<T> SaveAsync(T entity);
    }
}