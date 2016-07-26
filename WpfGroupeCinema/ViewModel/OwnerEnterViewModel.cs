using GroupeCinema.API;
using GroupeCinema.AsyncTask;
using GroupeCinema.Cinema;
using GroupeCinema.Database;
using GroupeCinema.Enums;
using GroupeCinema.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Windows.Threading;
using WpfGroupeCinema.CinemaListUserControl;
using WpfGroupeCinema.ViewModel;
using WpfGroupeCinema.Views;


namespace WpfGroupeCinema.ViewModel
{
    public class OwnerEnterViewModel
    {

        private OwnerEnterView ownerEnterView;

        public OwnerEnterView OwnerEnterView
        {
            get { return ownerEnterView; }
            set { ownerEnterView = value; }
        }



        public OwnerEnterViewModel(OwnerEnterView ownerEnterView)
        {
            this.ownerEnterView = ownerEnterView;
            this.OwnerEnterView.ownerUserControl.Owner = SetupOwner();
            this.OwnerEnterView.cinemaUserControl.Cinema = SetupCinema();


            this.OwnerEnterView.myBtn.Click += myBtn_Click;

            this.OwnerEnterView.cinemaListUserControl.cinemasListView.SelectionChanged += CinemasListView_SelectionChanged;

            this.OwnerEnterView.btnPopulate.Click += btnPopulate_Click;




            SetupCinemaList();

            //Sandbox sb = new Sandbox();
            //sb.testIt();

            //AsyncFactory af = new AsyncFactory();
            //af.TestIt();

            //MySQLManager<List<RegularClient>> manager3 = new MySQLManager<List<RegularClient>>(DataConnectionResource.LOCALMYQSL);
            //List<RegularClient> regClient = new RegularClient().LoadMultipleItems();
            //manager3.Insert(regClient);

            //Test();

        }

        private void CinemasListView_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            if ((Cinema)e.AddedItems[0] != null)
            {
                this.ownerEnterView.cinemaUserControl.Cinema = (Cinema)e.AddedItems[0];
            }
        }

        /*public async void Test()
        {*/
        /*WebServiceManager<Client> webService1 = new WebServiceManager<Client>(DataConnectionResource.LOCALAPI);
        Client reg = new Client().LoadSingleItem();
        Client apiResult;*/


        /*GroupeCinema.Cinema.ProductProvider provider = new ProductProvider();
        provider.Id = 1;
        provider.Firstname = "Jean";
        provider.Lastname = "Moineau";
        await Task.Factory.StartNew(() =>
        {
            MySQLManager<ProductProvider> manager4 = new MySQLManager<ProductProvider>(DataConnectionResource.LOCALMYQSL);
            manager4.Insert(provider);
        });*/


        //reg = await webService1.Post(reg);
        //apiResult = await webService1.Get(reg.Id);
        //}


        private void myBtn_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            
            this.OwnerEnterView.cinemaUserControl.Cinema = SetupCinema1();
            //Cinema currentCine = this.OwnerEnterView.cinemaListUserControl.;
            // this.OwnerEnterView.cinemaUserControl.Cinema;
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

        private GroupeCinema.Cinema.Owner SetupOwner()
        {
            GroupeCinema.Cinema.Owner owner = new GroupeCinema.Cinema.Owner();
            owner.Id = 1;
            owner.Firstname = "Michel";
            owner.Lastname = "Ladru";
            return owner;
        }

        private GroupeCinema.Cinema.Owner SetupClient1()
        {
            GroupeCinema.Cinema.Owner owner = new GroupeCinema.Cinema.Owner();

            owner.Id = 1;
            owner.Firstname = "Michel";
            owner.Lastname = "Ladru";
            return owner;
        }

        private Cinema SetupCinema()
        {
            GroupeCinema.Cinema.Cinema cinema = new GroupeCinema.Cinema.Cinema();
            cinema.Id = 1;
            cinema.Name = "Gaumont";
            cinema.Finance = 30000;
            return cinema;
        }
        private Cinema SetupCinema1()
        {
            GroupeCinema.Cinema.Cinema cinema = new GroupeCinema.Cinema.Cinema();
            cinema.Id = 1;
            cinema.Name = "Gaumont Paris";
            cinema.Finance = 300000;
            return cinema;
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
            if(results != null)
            {
                this.OwnerEnterView.cinemaListUserControl.LoadItems(results);
            }
             
        }


    }

   
}