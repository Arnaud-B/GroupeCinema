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
            MessageBoxResult result = MessageBox.Show("Do you want go to home ?", "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                this.NavigationService.Navigate(new HomeEnterView());
            }
        }

        private async void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            InitializeComponent();
            this.eatableEnterViewModel = new EatableEnterViewModel(this);
           
            Cinema cinema = this.cinema;

            Eatable eatable = new Eatable();
            eatable.Name = EatableEnterViewModel.EatableEnterView.addEatableUserControl.Name;
            eatable.Price = Decimal.Parse(EatableEnterViewModel.EatableEnterView.addEatableUserControl.Price);
            eatable.Weight = Decimal.Parse(EatableEnterViewModel.EatableEnterView.addEatableUserControl.Weight);
            eatable.Number = Int32.Parse(EatableEnterViewModel.EatableEnterView.addEatableUserControl.Number);
            eatable.BuyDate = DateTime.Now;
            eatable.Cinema_id = cinema.Id; 
          
             /*await Task.Factory.StartNew(() =>
             {
                 WebServiceManager<Eatable> manager1 = new WebServiceManager<Eatable>(DataConnectionResource.LOCALAPI);
                 manager1.Post(eatable);
             });*/

            await Task.Factory.StartNew(() =>
            {
                 MySQLManager<Eatable> manager = new MySQLManager<Eatable>(DataConnectionResource.LOCALMYQSL);
                 manager.Insert(eatable);
             });


        }
    }
}
