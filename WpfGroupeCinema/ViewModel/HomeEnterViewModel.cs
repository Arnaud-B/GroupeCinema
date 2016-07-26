using GroupeCinema.Cinema;
using GroupeCinema.Database;
using GroupeCinema.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using WpfGroupeCinema.Views;
using WpfGroupeCinema.Views.Pages;

namespace WpfGroupeCinema.ViewModel
{
    public class HomeEnterViewModel
    {
        private HomeEnterView homeEnterView;

        public HomeEnterView HomeEnterView
        {
            get { return homeEnterView; }
            set { homeEnterView = value; }
        }

        public HomeEnterViewModel(HomeEnterView homeEnterView)
        {
            this.homeEnterView = homeEnterView;
      
            this.HomeEnterView.myBtn.Click += myBtn_Click;

            this.HomeEnterView.cinemaListUserControl.cinemasListView.SelectionChanged += CinemasListView_SelectionChanged;

            this.HomeEnterView.btnPopulate.Click += btnPopulate_Click;


            SetupCinemaList();
        }
        private async void SetupCinemaList()
        {
            List<Cinema> results = new List<Cinema>();
            await Task.Factory.StartNew(() =>
            {
                MySQLManager<Cinema> manager5 = new MySQLManager<Cinema>(DataConnectionResource.LOCALMYQSL);
                results = manager5.Get().Result as List<Cinema>;
            });

            Console.WriteLine(results.Count);
            if (results != null)
            {
                this.HomeEnterView.cinemaListUserControl.LoadItems(results);
            }

        }
        private void myBtn_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            //this.HomeEnterView.cinemaListUserControl
            //this.NavigationService.Navigate(new CineEnterView());
        }

        private void CinemasListView_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            if ((Cinema)e.AddedItems[0] != null)
            {
                Console.WriteLine((Cinema)e.AddedItems[0]);
                this.homeEnterView.cinemaUserControl.Cinema = (Cinema)e.AddedItems[0];
                // Navigation fiche cine
                //this.homeEnterView.cinemaUserControl.Cinema = (Cinema)e.AddedItems[0];
            }
        }

        private async void btnPopulate_Click(object sender, System.Windows.RoutedEventArgs e)
        {

            List<Cinema> results = new List<Cinema>();
            await Task.Factory.StartNew(() =>
            {
                MySQLManager<Cinema> manager = new MySQLManager<Cinema>(DataConnectionResource.LOCALMYQSL);
                results = manager.Get().Result as List<Cinema>;
            });


            if (results.Count < 4)
            {
                #region Populate Database
                GroupeCinema.Cinema.Drinkable product = new Drinkable();
                product.Id = 1;
                product.Name = "Coca-Cola";
                product.Liter = new Decimal(1);
                product.Price = new Decimal(4);
                await Task.Factory.StartNew(() =>
                {
                    MySQLManager<Drinkable> manager2 = new MySQLManager<Drinkable>(DataConnectionResource.LOCALMYQSL);
                    manager2.Insert(product);
                });

                GroupeCinema.Cinema.Address address = new Address();
                address.Id = 1;
                address.City = "Paris";
                address.Number = 2;
                address.Path = "rue";
                address.Street = "Paix";

                GroupeCinema.Cinema.MovieProvider productor = new MovieProvider();
                productor.Id = 1;
                productor.Firstname = "Jean";
                productor.Lastname = "Moineau";
                productor.CompanyName = "Gaumont";
                productor.Address = address;
                await Task.Factory.StartNew(() =>
                {
                    MySQLManager<MovieProvider> manager4 = new MySQLManager<MovieProvider>(DataConnectionResource.LOCALMYQSL);
                    manager4.Insert(productor);
                });

                List<Cinema> result = new List<Cinema>();
                Cinema cinema = new Cinema();
                cinema.Id = 1;
                cinema.Name = "cinema 1";
                cinema.Finance = new decimal(10000);
                cinema.Address = address;
                result.Add(cinema);

                Cinema cinema1 = new Cinema();
                cinema1.Id = 2;
                cinema1.Name = "cinema 2";
                cinema1.Finance = new Decimal(150000);
                cinema1.Address = address;
                result.Add(cinema1);

                Cinema cinema2 = new Cinema();
                cinema2.Id = 3;
                cinema2.Name = "cinema 3";
                cinema2.Finance = new decimal(105000);
                cinema2.Address = address;
                result.Add(cinema2);

                Cinema cinema3 = new Cinema();
                cinema3.Id = 4;
                cinema3.Name = "cinema 4";
                cinema3.Finance = new Decimal(200000);
                cinema3.Address = address;
                result.Add(cinema3);
                await Task.Factory.StartNew(() =>
                {
                    MySQLManager<Cinema> manager4 = new MySQLManager<Cinema>(DataConnectionResource.LOCALMYQSL);
                    manager4.Insert(result);
                });
                #endregion
            }
        }
    }
}
