using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using NewProject.Models;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using static MaterialDesignThemes.Wpf.Theme;

namespace NewProject;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    private readonly DataContext _dataContext;
    private readonly ProductRepository _productRepository;


    public MainWindow()
    {
        InitializeComponent();

        MessageBox.Show("Домашня робота уч 008");

        var config = new ConfigurationBuilder()
                .AddJsonFile("config.json")
                .Build();

        DbContextOptions<DataContext> options = new DbContextOptionsBuilder<DataContext>()
            .UseSqlServer(config.GetConnectionString("Default"))
            .Options;

        _dataContext = new DataContext(options);
        _productRepository = new ProductRepository(_dataContext);

        //_dataContext.Product.Add(new Product()
        //{
        //    ProductName = "Product 1",
        //    ProductPrice = 100,
        //    ProductInfo = new ProductInfo()
        //    {
        //        Description = "Description for Product 1",
        //        Quantity = 5
        //    }
        //});
        //_dataContext.Product.Add(new Product()
        //{
        //    ProductName = "Product 2",
        //    ProductPrice = 150,
        //    ProductInfo = new ProductInfo()
        //    {
        //        Description = "Description for Product 2",
        //        Quantity = 11
        //    }
        //});
        //_dataContext.SaveChanges();
        //dg.ItemsSource = _dataContext.Product.ToList();

    }

    private async void bt_Add_Click(object sender, RoutedEventArgs e)
    {
        string productName = tbx_pName.Text;

        if (string.IsNullOrWhiteSpace(productName))
        {
            MessageBox.Show("Будь ласка, введіть назву продукту.");
            return;
        }

        if (!int.TryParse(tbx_pPrice.Text, out int productPrice))
        {
            MessageBox.Show("Будь ласка, введіть правильну вартість продукту.");
            return;
        }

        string productDescription = tbx_pDescription.Text;

        if (!int.TryParse(tbx_pQuantity.Text, out int productQuantity))
        {
            MessageBox.Show("Будь ласка, введіть правильну кількість продукту.");
            return;
        }

        Product newProduct = new Product
        {
            ProductName = productName,
            ProductPrice = productPrice,
            ProductInfo = new ProductInfo
            {
                Description = productDescription,
                Quantity = productQuantity
            }
        };
        try
        {
            await _productRepository.AddAsync(newProduct);

            tbx_pName.Text = string.Empty;
            tbx_pPrice.Text = string.Empty;
            tbx_pDescription.Text = string.Empty;
            tbx_pQuantity.Text = string.Empty;

            await _dataContext.SaveChangesAsync();
            dg.ItemsSource = _dataContext.Product.ToList();
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Помилка додавання продукту: {ex.Message}");
        }
        
    }
}