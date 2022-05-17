using Dukkantek.Inventory.Infrastructure.Context;
using Dukkantek.Inventory.Infrastructure.Repositories.Interface;
using Dukkantek.Inventory.Model.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Dukkantek.Inventory.Infrastructure.Repositories.Implementation
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly InventoryDbContext _context;
        private readonly DbSet<T> _entities;

        public Repository(InventoryDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _entities = context.Set<T>();
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _entities.ToListAsync();
        }

        public async Task<T> GetByIdAsync(long id)
        {
            return await _entities.SingleOrDefaultAsync(s => s.Id == id);
        }

        public void Add(T entity)
        {
            _entities.Add(entity);
        }

        public async Task<T> FindByConditionAsync(Expression<Func<T, bool>> predicate)
        {
            return await _context.Set<T>().FirstOrDefaultAsync(predicate);
        }

        public async Task<bool> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync().ConfigureAwait(false) > 0;
        }
    }
}
