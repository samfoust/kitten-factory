using KittenFactory.Application.Models;
using KittenFactory.Application.Models.Base;

namespace KittenFactory.Application.Services.Interfaces
{
    public interface IBaseService<T> where T : BaseModel
    {
        Task DeleteByIdAsync(int id);
        Task<T> GetByIdAsync(int id);
        Task<IEnumerable<T>> GetCatsAsync();
        Task<T> SaveAsync(T entity);
    }
}