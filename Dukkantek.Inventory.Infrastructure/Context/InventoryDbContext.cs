using Dukkantek.Inventory.Model.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Dukkantek.Inventory.Infrastructure.Context
{
    public class InventoryDbContext : DbContext
    {
        protected readonly IConfiguration _configuration;

        public InventoryDbContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            
            options.UseSqlServer(_configuration.GetConnectionString("DukkantekInventoryDb"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            new InventoryDbInitializer(modelBuilder).Seed();
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
    }
}
