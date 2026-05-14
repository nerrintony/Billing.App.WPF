using Test.ShopBilling.WPFApp.Models;

namespace Test.ShopBilling.WPFApp.Services
{
    public interface IProductService
    {
        Task AddProductAsync(Product product);
        Task<List<Product>> GetProductAsync();
    }
}
