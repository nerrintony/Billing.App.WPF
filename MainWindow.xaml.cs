using System.Windows;
using Test.ShopBilling.WPFApp.Models;
using Test.ShopBilling.WPFApp.Services;

namespace Test.ShopBilling.WPFApp
{
    public partial class MainWindow : Window
    {
        private readonly IProductService _productService;

        public MainWindow(IProductService productService)
        {
            InitializeComponent();

            _productService = productService;

            Loaded += MainWindow_Loaded;
        }

        private async void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            await TestDatabase();
        }

        private async Task TestDatabase()
        {
            try
            {
                await _productService.AddProductAsync(new Product
                {
                    ProductName = "Rice",
                    ProductPrice = 100,
                    ProductQuantity = 5
                });

                var products = await _productService.GetProductAsync();

                MessageBox.Show($"Products Count: {products.Count}");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}