using System.Linq.Expressions;

namespace Dukkantek.Inventory.Infrastructure.Repositories.Interface
{
    public interface IRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetByIdAsync(long id);
        void Add(T entity);
        Task<bool> SaveChangesAsync();
        Task<T> FindByConditionAsync(Expression<Func<T, bool>> predicate);
    }
}
