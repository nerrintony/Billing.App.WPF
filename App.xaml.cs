using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Windows;
using Test.ShopBilling.WPFApp.Data;
using Test.ShopBilling.WPFApp.Services;

namespace Test.ShopBilling.WPFApp
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static IHost? AppHost { get; private set; }

        public App()
        {
            AppHost = Host.CreateDefaultBuilder()
                .ConfigureServices((context, services) =>
                {
                    //DbContext
                    services.AddDbContext<BillingDbContext>(options =>
                    {
                        var dbPath = @"D:\Projects\Test.ShopBilling.WPFApp\ShopBilling.db";

                        options.UseSqlite($"Data Source={dbPath}");

                    }, ServiceLifetime.Singleton);

                    //services.AddSingleton<BillingDbContext>();

                    services.AddSingleton<IProductService, ProductService>();

                    services.AddSingleton<MainWindow>();
                })
                .Build();
        }

        protected override async void OnStartup(StartupEventArgs e)
        {
            await AppHost!.StartAsync();

            var mainWindow = AppHost.Services.GetRequiredService<MainWindow>();

            mainWindow.Show();

            base.OnStartup(e);
        }

        protected override async void OnExit(ExitEventArgs e)
        {
            await AppHost!.StopAsync();

            base.OnExit(e);
        }
    }

}
