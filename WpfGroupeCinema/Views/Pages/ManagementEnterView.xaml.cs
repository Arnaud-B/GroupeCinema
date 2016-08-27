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
    /// Interaction logic for ManagementEnterView.xaml
    /// </summary>
    public partial class ManagementEnterView : Page
    {
        private ManagementEnterViewModel managementEnterViewModel;
        private Cinema cinema;
        public ManagementEnterViewModel ManagementEnterViewModel
        {
            get { return managementEnterViewModel; }
            set { managementEnterViewModel = value; }
        }
        public ManagementEnterView()
        {
            InitializeComponent();
            this.managementEnterViewModel = new ManagementEnterViewModel(this);
        }
        public ManagementEnterView(Cinema cinema)
        {
            InitializeComponent();
            this.cinema = cinema;
            this.managementEnterViewModel = new ManagementEnterViewModel(this, cinema);
                        
            ManagementEnterViewModel.ManagementEnterView.movieCinemaUserControl.BtnMovie.Click += BtnMovie_Click;

            ManagementEnterViewModel.ManagementEnterView.productManagementUserControl.BtnDrinkable.Click += BtnDrinkable_Click;

            ManagementEnterViewModel.ManagementEnterView.productManagementUserControl.BtnEatable.Click += BtnEatable_Click;

            ManagementEnterViewModel.ManagementEnterView.productManagementUserControl.BtnProduct.Click += BtnProduct_Click;

            ManagementEnterViewModel.ManagementEnterView.homeUserControl.BtnHome.Click += BtnNavigate_Click;
        }

       
        private void BtnMovie_Click(object sender, RoutedEventArgs e)
        {
            if (this.cinema != null)
            {
                this.NavigationService.Navigate(new MovieEnterView(this.cinema));
            }
        }
        private void BtnDrinkable_Click(object sender, RoutedEventArgs e)
        {
            if (this.cinema != null)
            {
                this.NavigationService.Navigate(new DrinkableEnterView(this.cinema));
            }
        }
        private void BtnEatable_Click(object sender, RoutedEventArgs e)
        {
            if (this.cinema != null)
            {
                this.NavigationService.Navigate(new EatableEnterView(this.cinema));
            }
        }
        private void BtnProduct_Click(object sender, RoutedEventArgs e)
        {
            if (this.cinema != null)
            {
                this.NavigationService.Navigate(new ProductGestionEnterView(this.cinema));
            }
        }

        private void BtnNavigate_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Do you want go to home ?", "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                this.NavigationService.Navigate(new HomeEnterView());
            }
        }
    }
}
