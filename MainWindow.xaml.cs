using System.Windows;
using Test.ShopBilling.WPFApp.Models;
using Test.ShopBilling.WPFApp.Services;
using Test.ShopBilling.WPFApp.ViewModels;

namespace Test.ShopBilling.WPFApp
{
    public partial class MainWindow : Window
    {
        private readonly IProductService _productService;

        public MainWindow(IProductService productService)
        {
            InitializeComponent();

            _productService = productService;

            var vm = new ProductViewModel();
            vm.ProductName = "initial Product";
            DataContext = vm;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var vm = (ProductViewModel)DataContext;

            vm.Products.Add(new Product
            {
                ProductName = vm.ProductName,
                ProductPrice = vm.ProductPrice,
                ProductQuantity = 1
            });
        }
    }
}