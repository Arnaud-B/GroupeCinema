using GroupeCinema.Cinema;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfGroupeCinema
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ObservableCollection<Product> products;
        private ObservableCollection<Product> productsToBuy;
        private ObservableCollection<Product> productsBought;
        private Client client;

        public MainWindow()
        {
            InitializeComponent();
            client = BaseTestClient();

            products = BaseTestProducts();
            productsToBuy = new ObservableCollection<Product>();
            //productsBought = new ObservableCollection<Product>(client.Products);

            this.textBlock.Text = client.Firstname;
            this.textBlock1.Text = client.Lastname;
            this.textBlock2.Text = client.Money.ToString();

            this.listView1.ItemsSource = products;
            this.listView.ItemsSource = productsToBuy;
            this.listView2.ItemsSource = productsBought;
        }

        private ObservableCollection<Product> BaseTestProducts()
        {
            ObservableCollection<Product> result = new ObservableCollection<Product>();

            #region Products creation
            Product product1 = new Eatable();
            product1.Id = 1;
            product1.Name = "product 1";
            product1.Price = new Decimal(10);
            result.Add(product1);

            Product product2 = new Eatable();
            product2.Id = 2;
            product2.Name = "product 2";
            product2.Price = new Decimal(20);
            result.Add(product2);

            Product product3 = new Eatable();
            product3.Id = 3;
            product3.Name = "product 3";
            product3.Price = new Decimal(30);
            result.Add(product3);

            Product product4 = new Eatable();
            product4.Id = 4;
            product4.Name = "product 4";
            product4.Price = new Decimal(40);
            result.Add(product4);

            Product product5 = new Eatable();
            product5.Id = 5;
            product5.Name = "product 5";
            product5.Price = new Decimal(50);
            result.Add(product5);

            Product product6 = new Drinkable();
            product6.Id = 6;
            product6.Name = "product 6";
            product6.Price = new Decimal(60);
            result.Add(product6);

            Product product7 = new Drinkable();
            product7.Id = 7;
            product7.Name = "product 7";
            product7.Price = new Decimal(70);
            result.Add(product7);

            Product product8 = new Drinkable();
            product8.Id = 8;
            product8.Name = "product 8";
            product8.Price = new Decimal(80);
            result.Add(product8);

            Product product9 = new Drinkable();
            product9.Id = 9;
            product9.Name = "product 9";
            product9.Price = new Decimal(90);
            result.Add(product9);

            Product product10 = new Drinkable();
            product10.Id = 10;
            product10.Name = "product 10";
            product10.Price = new Decimal(100);
            result.Add(product10);
            #endregion

            return result;
        }

        private Client BaseTestClient()
        {
            Client client = new Client();
            client.Firstname = "Gramm";
            client.Lastname = "Gilbert";
            client.Money = new Decimal(200.20);
            return client;
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            //buy
            Decimal moneyToBuy = 0;
            foreach (var item in this.productsToBuy)
            {
                moneyToBuy += item.Price;
            }
            if (this.client.Money >= moneyToBuy)
            {
                this.client.Money -= moneyToBuy;
                //this.client.Products.AddRange(this.productsToBuy);
                this.productsBought.Clear();
                /*foreach (var item in this.client.Products)
                {
                    this.productsBought.Add(item);
                }*/
                this.productsToBuy.Clear();
                this.textBlock2.Text = this.client.Money.ToString();
            }
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            //add
            this.productsToBuy.Add(this.listView1.SelectedItem as Product);
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            //remove
            this.productsToBuy.Remove(this.listView.SelectedItem as Product);
        }
     
    }
}
