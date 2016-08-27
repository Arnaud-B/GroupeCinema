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
    /// Interaction logic for MovieRoomEnterView.xaml
    /// </summary>
    public partial class MovieRoomEnterView : Page
    {
        private Cinema cinema;
        private Movie movie;
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
            MovieRoomEnterViewModel.MovieRoomEnterView.homeUserControl.BtnHome.Click += BtnNavigate_Click;

            MovieRoomEnterViewModel.MovieRoomEnterView.movieListUserControl.moviesListView.SelectionChanged += MovieListView_SelectionChanged;
            MovieRoomEnterViewModel.MovieRoomEnterView.chooseMovieUserControl.btnChoose.Click += BtnSelectMovie_Click;
        }

        private void MovieListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if ((Movie)e.AddedItems[0] != null)
            {
                Movie movie = new Movie();
                movie = (Movie)e.AddedItems[0];
                this.movie = movie;
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

        private async void BtnSelectMovie_Click(object sender, RoutedEventArgs e)
        { 
            if(this.cinema != null && this.movie != null)
            {
                List<MovieRoom> results = new List<MovieRoom>();
                await Task.Factory.StartNew(() =>
                {
                    MySQLManager<MovieRoom> manager5 = new MySQLManager<MovieRoom>(DataConnectionResource.LOCALMYQSL);
                    results = manager5.Get().Result as List<MovieRoom>;
                });
                if(results != null)
                {
                    foreach(var res in results)
                    {
                        if (res.Cinema_id == this.cinema.Id && res.Movie_id == this.movie.Id)
                        {
                            MovieRoom movieRoom = res;
                            this.NavigationService.Navigate(new SelectMovieEnterView(this.cinema, this.movie, movieRoom));                      
                        }
                    }
                }

                
            }
        }
    }
}
