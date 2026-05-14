using Microsoft.EntityFrameworkCore;
using Test.ShopBilling.WPFApp.Data;
using Test.ShopBilling.WPFApp.Models;

namespace Test.ShopBilling.WPFApp.Services
{
    public class ProductService : IProductService
    {
        private readonly BillingDbContext _context;

        public ProductService(BillingDbContext context)
        {
            _context = context;
        }

        public async Task AddProductAsync(Product product)
        {
            if (string.IsNullOrWhiteSpace(product.ProductName)) throw new Exception("Product name is required");
            
            if (product.ProductPrice <= 0) throw new Exception("Product price must be greater than zero");

            await _context.Products.AddAsync(product);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Product>> GetProductAsync()
        {
            return await _context.Products.ToListAsync();
        }
    }
}
