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
    /// Interaction logic for SelectMovieEnterView.xaml
    /// </summary>
    public partial class SelectMovieEnterView : Page
    {

        private SelectMovieEnterViewModel selectMovieEnterViewModel;

        public SelectMovieEnterViewModel SelectMovieEnterViewModel
        {
            get { return selectMovieEnterViewModel; }
            set { selectMovieEnterViewModel = value; }
        }
        public SelectMovieEnterView()
        {
            InitializeComponent();
            this.selectMovieEnterViewModel = new SelectMovieEnterViewModel(this);
        }
        public SelectMovieEnterView(Cinema cinema, Movie movie, MovieRoom movieRoom)
        {
            InitializeComponent();
            this.selectMovieEnterViewModel = new SelectMovieEnterViewModel(this, cinema, movie, movieRoom);

            SelectMovieEnterViewModel.SelectMovieEnterView.cinemaUserControl.Cinema = cinema;
            SelectMovieEnterViewModel.SelectMovieEnterView.updateMovieUserControl.Movie = movie;
            SelectMovieEnterViewModel.SelectMovieEnterView.updateMovieUserControl.MovieRoom = movieRoom;
            SelectMovieEnterViewModel.SelectMovieEnterView.homeUserControl.BtnHome.Click += BtnNavigate_Click;
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
