using GroupeCinema.Cinema;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfGroupeCinema.Views;

namespace WpfGroupeCinema.ViewModel
{
    public class CinemaEnterViewModel
    {
        
        private CinemaEnterView cinemaEnterView;

        public CinemaEnterView CinemaEnterView
        {
            get { return cinemaEnterView; }
            set { cinemaEnterView = value; }
        }

        public CinemaEnterViewModel(CinemaEnterView cinemaEnterView)
        {
            this.cinemaEnterView = cinemaEnterView;
            this.CinemaEnterView.ownerUserControl.Owner = SetupOwner();
            //this.CinemaEnterView.eatableListUserControl.LoadItems(SetupEatbleList());
            //this.CinemaEnterView.drinkableListUserControl.LoadItems(SetupDrinkableList());
            this.CinemaEnterView.myBtn.Click += MyBtn_Click;
        }

        /*private List<Eatable> SetupEatbleList()
        {
            throw new NotImplementedException();
        }*/

        /*private object SetupDrinkableList()
        {
            List<Drinkable> results = new List<Drinkable>();
            await Task.Factory.StartNew(() =>
            {
                MySQLManager<Cinema> manager5 = new MySQLManager<Cinema>(DataConnectionResource.LOCALMYQSL);
                results = manager5.Get().Result as List<Cinema>;
            });

            Console.WriteLine(results.Count);
            if (results != null)
            {
                this.CinemaEnterView.drinkableListUserControl.LoadItems(results);
            }
        }*/

        private void MyBtn_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            this.CinemaEnterView.ownerUserControl.Owner = SetupOwner1();
        }

        /*private List<Product> SetupProductList()
        {
            List<Product> result = new List<Product>();

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
        }*/


        /*private Product SetupProduct()
        {
            GroupeCinema.Cinema.Product product = new Eatable();
            product.Id = 1;
            product.Name = "Pop Corn";
            product.Price = new Decimal(4);
            return product;
        }*/

        private GroupeCinema.Cinema.Owner SetupOwner()
        {
            GroupeCinema.Cinema.Owner owner = new GroupeCinema.Cinema.Owner();
            owner.Id = 1;
            owner.Firstname = "Michel";
            owner.Lastname = "Ladru";
            return owner;
        }

        private GroupeCinema.Cinema.Owner SetupOwner1()
        {
            GroupeCinema.Cinema.Owner owner = new GroupeCinema.Cinema.Owner();
            owner.Id = 3;
            owner.Firstname = "Bernard";
            owner.Lastname = "Lafite";
            return owner;
        }

    }
}
