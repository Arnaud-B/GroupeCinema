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
    /// Interaction logic for HomeCinemaEnterView.xaml
    /// </summary>
    public partial class HomeCinemaEnterView : Page
    {
        private HomeCinemaEnterViewModel homeCinemaEnterViewModel;
        private Cinema cinema;

        public HomeCinemaEnterViewModel HomeCinemaEnterViewModel
        {
            get { return homeCinemaEnterViewModel; }
            set { homeCinemaEnterViewModel = value; }
        }


        public HomeCinemaEnterView()
        {
            InitializeComponent();
            this.homeCinemaEnterViewModel = new HomeCinemaEnterViewModel(this);
        }

        public HomeCinemaEnterView(Cinema cinema)
        {
            InitializeComponent();
            this.homeCinemaEnterViewModel = new HomeCinemaEnterViewModel(this);
            this.cinema = cinema;
            HomeCinemaEnterViewModel.HomeCinemaEnterView.cinemaUserControl.Cinema = cinema;
        }

    

        private void BtnProducts_Click(object sender, RoutedEventArgs e)
        {
            if (this.cinema != null)
            {
                this.NavigationService.Navigate(new ProductEnterView(this.cinema));
            }
        }

        private void BtnMovies_Click(object sender, RoutedEventArgs e)
        {
            if (this.cinema != null)
            {
                Console.WriteLine(cinema.Id);
                Console.WriteLine(cinema.Finance);
            }
        }

        private void BtnManagement_Click(object sender, RoutedEventArgs e)
        {
            if (this.cinema != null)
            {
                Console.WriteLine(cinema.Id);
                Console.WriteLine(cinema.Finance);
            }
        }

        private void BtnNavigate_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new HomeEnterView());
        }
    }
}
