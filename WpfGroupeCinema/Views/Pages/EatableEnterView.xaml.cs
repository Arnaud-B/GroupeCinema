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
            this.NavigationService.Navigate(new HomeEnterView());
        }

        private async void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            InitializeComponent();
            this.eatableEnterViewModel = new EatableEnterViewModel(this);
            Console.WriteLine(EatableEnterViewModel.EatableEnterView.Name.Text);
            Console.WriteLine(EatableEnterViewModel.EatableEnterView.Price.Text);

            Cinema cinema = this.cinema;


            Eatable eatable = new Eatable();
            eatable.Name = EatableEnterViewModel.EatableEnterView.Name.Text;
            eatable.Price = Decimal.Parse(EatableEnterViewModel.EatableEnterView.Price.Text);
            eatable.Number = Decimal.Parse(EatableEnterViewModel.EatableEnterView.Weight.Text);
            eatable.Cinema_id = cinema.Id;
            await Task.Factory.StartNew(() =>
            {
                WebServiceManager<Eatable> manager1 = new WebServiceManager<Eatable>(DataConnectionResource.LOCALAPI);
                manager1.Post(eatable);
            });
            await Task.Factory.StartNew(() =>
            {
                MySQLManager<Eatable> manager = new MySQLManager<Eatable>(DataConnectionResource.LOCALAPI);
                manager.Insert(eatable);
            });


            /*Cinema cinemaChoose = new Cinema();
            await Task.Factory.StartNew(() =>
            {
                MySQLManager<Cinema> manager = new MySQLManager<Cinema>(DataConnectionResource.LOCALMYQSL);
                cinemaChoose = manager.Get(cinema.Id).Result as Cinema;
            });
            Console.WriteLine(cinemaChoose.Id);*/

            /*List<Eatable> eatables = new List<Eatable>();
            eatables.Add(eatable);
            cinemaChoose.Eatables = eatables;*/

            MySQLManager<Cinema> manager5 = new MySQLManager<Cinema>(DataConnectionResource.LOCALMYQSL);
            //await manager5.Get(cinema.Id);
            //manager5.DbSetT.Add(cinema);
            //cinema.Name = "pouet";
            var result = await manager5.Get(cinema.Id);
         
            result.Name = "pouet";
            await manager5.Update(result);

        


            /*Cinema cine = new Cinema();
            cine.Name = "toto";
            await manager5.Insert(cine);
            cine.Name = "tata";
            await manager5.Update(cine);*/

;
         




        }
    }
}
