using GroupeCinema.API;
using GroupeCinema.Cinema;
using GroupeCinema.Database;
using GroupeCinema.Enums;
using System;
using System.Collections.Generic;
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
using WpfGroupeCinema.ViewModel;

namespace WpfGroupeCinema.Views
{
    /// <summary>
    /// Interaction logic for EatableEnterView.xaml
    /// </summary>
    public partial class EatableEnterView : Page
    {
        private EatableEnterViewModel eatableEnterViewModel;
        private Cinema cinema;

        public EatableEnterViewModel EatableEnterViewModel
        {
            get { return eatableEnterViewModel; }
            set { eatableEnterViewModel = value; }
        }

        public EatableEnterView()
        {
            InitializeComponent();
            this.eatableEnterViewModel = new EatableEnterViewModel(this);
        }

        public EatableEnterView(Cinema cinema)
        {
            InitializeComponent();
            this.eatableEnterViewModel = new EatableEnterViewModel(this);
            this.cinema = cinema;
            EatableEnterViewModel.EatableEnterView.cinemaUserControl.Cinema = cinema;
        }

        private void BtnNavigate2_Click(object sender, RoutedEventArgs e)
        {

        }
        private async void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            InitializeComponent();
            this.eatableEnterViewModel = new EatableEnterViewModel(this);
            Console.WriteLine(EatableEnterViewModel.EatableEnterView.Name.Text);
            Console.WriteLine(EatableEnterViewModel.EatableEnterView.Price.Text);

            Cinema cinema = this.cinema;

            Console.WriteLine(cinema.Name);

     
            Cinema cinemaChoose = new Cinema();
            await Task.Factory.StartNew(() =>
            {
                MySQLManager<Cinema> manager = new MySQLManager<Cinema>(DataConnectionResource.LOCALMYQSL);
                cinemaChoose = manager.Get(cinema.Id).Result as Cinema;
            });
            Console.WriteLine(cinemaChoose.Id);

            GroupeCinema.Cinema.Eatable eatable = new Eatable();
            eatable.Price = Decimal.Parse(EatableEnterViewModel.EatableEnterView.Price.Text);
            eatable.Name = EatableEnterViewModel.EatableEnterView.Name.Text;
            eatable.Temp = true;
            eatable.BuyDate = DateTime.Now;


            /*
            Cinema cinemaTmp = new Cinema();
            await Task.Factory.StartNew(() =>
            {
                WebServiceManager<Cinema> manager = new WebServiceManager<Cinema>(DataConnectionResource.LOCALAPI);
                cinemaTmp = manager.Get(cinemaChoose.Id).Result as Cinema;
            });
            Console.WriteLine("Result API");
            Console.WriteLine(cinemaTmp.Name);
            */
            /*
            await Task.Factory.StartNew(() =>
            {
                WebServiceManager<Eatable> manager1 = new WebServiceManager<Eatable>(DataConnectionResource.LOCALAPI);
                manager1.Post(eatable);
                MySQLManager<Eatable> manager1 = new MySQLManager<Eatable>(DataConnectionResource.LOCALMYQSL);
                manager1.Insert(eatable);

            });
            */


            //cinemaChoose.Name = "Gaumont";

            /*List<Eatable> eatables = new List<Eatable>();
            eatables.Add(eatable);*/
            /*cinemaChoose.Eatables = eatables;
            Console.WriteLine(cinemaChoose.Eatables);*/
            /*await Task.Factory.StartNew(() =>
            {
                MySQLManager<Cinema> manager5 = new MySQLManager<Cinema>(DataConnectionResource.LOCALMYQSL);
                manager5.Update(cinemaChoose);
            });*/


            eatable.Cinema = cinemaChoose;
            await Task.Factory.StartNew(() =>
            {
                MySQLManager<Eatable> manager1 = new MySQLManager<Eatable>(DataConnectionResource.LOCALMYQSL);
                manager1.Insert(eatable);
            });
            //Console.WriteLine(cinemaChoose.Name);
            //Console.WriteLine(cinemaChoose.Id);
            //Console.WriteLine(cinemaChoose.Name);



        }
    }
}
