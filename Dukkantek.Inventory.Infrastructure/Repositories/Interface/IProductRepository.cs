using Dukkantek.Inventory.Model.Entities;
using Dukkantek.Inventory.Model.Models.Product;

namespace Dukkantek.Inventory.Infrastructure.Repositories.Interface
{
    public interface IProductRepository : IRepository<Product>
    {
        Task<List<CountProductsDto>> CountProductsByStatus();
    }
}
