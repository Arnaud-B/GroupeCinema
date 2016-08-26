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
    /// Interaction logic for MovieEnterView.xaml
    /// </summary>
    public partial class MovieEnterView : Page
    {
        private Cinema cinema;
        private MovieEnterViewModel movieEnterViewModel;

        public MovieEnterViewModel MovieEnterViewModel
        {
            get { return movieEnterViewModel; }
            set { movieEnterViewModel = value; }
        }
        public MovieEnterView()
        {
            InitializeComponent();
            this.movieEnterViewModel = new MovieEnterViewModel(this);
        }
        public MovieEnterView(Cinema cinema)
        {
            InitializeComponent();
            this.movieEnterViewModel = new MovieEnterViewModel(this);
            this.cinema = cinema;
            MovieEnterViewModel.MovieEnterView.cinemaUserControl.Cinema = cinema;
            MovieEnterViewModel.MovieEnterView.homeUserControl.BtnHome.Click += BtnNavigate_Click;
        }

        private void btnAddMovie_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new AddMovieEnterView(this.cinema));
        }

        private void btnMovie_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new MovieRoomEnterView(this.cinema));
        }

        private void btnRoom_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnNavigate_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new HomeEnterView());
        }
    }
}
