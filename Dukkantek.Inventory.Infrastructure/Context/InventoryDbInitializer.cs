using Dukkantek.Inventory.Model.Entities;
using Dukkantek.Inventory.Model.Models.Enum;
using Microsoft.EntityFrameworkCore;

namespace Dukkantek.Inventory.Infrastructure.Context
{
    public class InventoryDbInitializer
    {
        private readonly ModelBuilder _modelBuilder;

        public InventoryDbInitializer(ModelBuilder modelBuilder)
        {
            this._modelBuilder = modelBuilder;
        }

        public void Seed()
        {
            _modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "Category 1", },
                new Category { Id = 2, Name = "Category 2", }
                );

            _modelBuilder.Entity<Product>().HasData(
                new Product { Id = 1, Name = "Product 1", Barcode = "123456789", Description = "Product 1 Description", Status = ProductStatus.Sold.ToString(), Weight = "0.95 kg", CategoryId = 1 },
                new Product { Id = 2, Name = "Product 2", Barcode = "123456789", Description = "Product 2 Description", Status = ProductStatus.Sold.ToString(), Weight = "0.75 kg", CategoryId = 2 },
                new Product { Id = 3, Name = "Product 3", Barcode = "123456789", Description = "Product 3 Description", Status = ProductStatus.Sold.ToString(), Weight = "0.70 kg", CategoryId = 1 },
                new Product { Id = 4, Name = "Product 4", Barcode = "123456789", Description = "Product 4 Description", Status = ProductStatus.InStock.ToString(), Weight = "2 kg", CategoryId = 2 },
                new Product { Id = 5, Name = "Product 5", Barcode = "123456789", Description = "Product 5 Description", Status = ProductStatus.InStock.ToString(), Weight = "1.5 kg", CategoryId = 1 },
                new Product { Id = 6, Name = "Product 6", Barcode = "123456789", Description = "Product 6 Description", Status = ProductStatus.InStock.ToString(), Weight = "2 kg", CategoryId = 2 },
                new Product { Id = 7, Name = "Product 7", Barcode = "123456789", Description = "Product 7 Description", Status = ProductStatus.InStock.ToString(), Weight = "0.5 kg", CategoryId = 1 },
                new Product { Id = 8, Name = "Product 8", Barcode = "123456789", Description = "Product 8 Description", Status = ProductStatus.InStock.ToString(), Weight = "1.5 kg", CategoryId = 2 },
                new Product { Id = 9, Name = "Product 9", Barcode = "123456789", Description = "Product 9 Description", Status = ProductStatus.InStock.ToString(), Weight = "2.75 kg", CategoryId = 1 },
                new Product { Id = 10, Name = "Product 10", Barcode = "123456789", Description = "Product 10 Description", Status = ProductStatus.Damaged.ToString(), Weight = "0.65 kg", CategoryId = 2 }
                );
        }
    }
}
