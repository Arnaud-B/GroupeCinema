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
    /// Interaction logic for MovieRoomEnterView.xaml
    /// </summary>
    public partial class MovieRoomEnterView : Page
    {
        private Cinema cinema;
        private MovieRoomEnterViewModel movieRoomEnterViewModel;

        public MovieRoomEnterViewModel MovieRoomEnterViewModel
        {
            get { return movieRoomEnterViewModel; }
            set { movieRoomEnterViewModel = value; }
        }

        public MovieRoomEnterView()
        {
            InitializeComponent();
            this.MovieRoomEnterViewModel = new MovieRoomEnterViewModel(this);
        }

        public MovieRoomEnterView(Cinema cinema)
        {
            InitializeComponent();
            this.cinema = cinema;
            this.MovieRoomEnterViewModel = new MovieRoomEnterViewModel(this, cinema);
            MovieRoomEnterViewModel.MovieRoomEnterView.cinemaUserControl.Cinema = cinema;

        }

        private void BtnNavigate2_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new HomeEnterView());
        }
    }
}
