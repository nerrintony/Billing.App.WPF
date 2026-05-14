using Microsoft.EntityFrameworkCore;
using Test.ShopBilling.WPFApp.Models;

namespace Test.ShopBilling.WPFApp.Data
{
    public class BillingDbContext : DbContext
    {
        public BillingDbContext(DbContextOptions<BillingDbContext> options) : base(options) { }
        public DbSet<Product> Products { get; set; }
    }
}
