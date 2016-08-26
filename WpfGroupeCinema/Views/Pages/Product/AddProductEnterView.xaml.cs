using GroupeCinema.Cinema;
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
    /// Interaction logic for AddProductEnterView.xaml
    /// </summary>
    public partial class AddProductEnterView : Page
    {

        private AddProductEnterViewModel addProductEnterViewModel;
        private Cinema cinema;

        public AddProductEnterViewModel AddProductEnterViewModel
        {
            get { return addProductEnterViewModel; }
            set { addProductEnterViewModel = value; }
        }

        public AddProductEnterView()
        {
            InitializeComponent();
            this.addProductEnterViewModel = new AddProductEnterViewModel(this);
        }

        public AddProductEnterView(Cinema cinema)
        {
            InitializeComponent();
            this.addProductEnterViewModel = new AddProductEnterViewModel(this);
            this.cinema = cinema;
            AddProductEnterViewModel.AddProductEnterView.cinemaUserControl.Cinema = cinema;
            AddProductEnterViewModel.AddProductEnterView.homeUserControl.BtnHome.Click += BtnNavigate_Click;
        }

        private void BtnNavigate_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Do you want go to home ?", "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                this.NavigationService.Navigate(new HomeEnterView());
            }
        }

        private void btnEatable_Click(object sender, RoutedEventArgs e)
        {
            if (this.cinema != null)
            {
                this.NavigationService.Navigate(new EatableEnterView(this.cinema));
            }
        }

        private void btnDrinkable_Click(object sender, RoutedEventArgs e)
        {
            if (this.cinema != null)
            {
                this.NavigationService.Navigate(new DrinkableEnterView(this.cinema));
            }
        }
    }
}
