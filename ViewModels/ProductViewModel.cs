using System.Collections.ObjectModel;
using Test.ShopBilling.WPFApp.Models;

namespace Test.ShopBilling.WPFApp.ViewModels
{
    public class ProductViewModel : BaseViewModel
    {
        private string _productName = string.Empty;

        public ObservableCollection<Product> Products { get; set; } = new ObservableCollection<Product>();

        public ProductViewModel()
        {
            Products.Add(new Product
            {
                ProductName = "Rice",
                ProductPrice = 100,
                ProductQuantity = 5
            });

            Products.Add(new Product
            {
                ProductName = "Milk",
                ProductPrice = 50,
                ProductQuantity = 2
            });
        }

        public string ProductName
        {
            get => _productName;
            set
            {
                _productName = value;
                OnPropertyChange();
            }
        }

        private decimal _productPrice;

        public decimal ProductPrice
        {
            get => _productPrice;
            set
            {
                _productPrice = value;
                OnPropertyChange();
            }
        }

    }
}
