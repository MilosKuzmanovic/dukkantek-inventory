using Dukkantek.Inventory.Infrastructure.Context;
using Dukkantek.Inventory.Model.Entities;
using Dukkantek.Inventory.Infrastructure.Repositories.Interface;
using Microsoft.EntityFrameworkCore;
using Dukkantek.Inventory.Model.Models.Product;

namespace Dukkantek.Inventory.Infrastructure.Repositories.Implementation
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        readonly InventoryDbContext _context;

        public ProductRepository(InventoryDbContext context) : base(context)
        {
            _context = context;
        }

        public Task<List<CountProductsDto>> CountProductsByStatus()
        {
            return _context.Products
                .GroupBy(product => product.Status)
                .Select(productGroup => new CountProductsDto
                {
                    Status = productGroup.First().Status,
                    Count = productGroup.Count()
                })
                .ToListAsync();
        }
    }
}
