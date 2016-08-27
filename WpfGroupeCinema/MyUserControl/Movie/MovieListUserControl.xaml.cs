using GroupeCinema.Cinema;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace WpfGroupeCinema.CinemaListUserControl
{
    /// <summary>
    /// Interaction logic for MovieListUserControl.xaml
    /// </summary>
    public partial class MovieListUserControl : BaseUserControl
    {
        #region Attributes
        private ObservableCollection<Movie> movies;
        #endregion
        public ListView listView { get; set; }

        public object MyListBoxSelectedValue
        {
            get { return ListBox.SelectedEvent; }
        }

        public ObservableCollection<Movie> Movies
        {
            get { return this.movies; }
            set
            {
                this.movies = value;
                OnPropertyChanged("Movies");
            }
        }

        public MovieListUserControl()
        {
            InitializeComponent();
            this.Movies = new ObservableCollection<Movie>();
            this.moviesListView.ItemsSource = this.Movies;
            this.listView = this.moviesListView;
        }

        public void LoadItems(List<Movie> items)
        {
            this.Movies.Clear();
            foreach (var item in items)
            {
                Movies.Add(item);
            }
        }
        public void LoadItems(List<Movie> items, List<MovieRoom> movieRooms)
        {
            this.Movies.Clear();
            foreach (var item in items)
            {
                foreach (var movieRoom in movieRooms)
                {
                    if (item.Id == movieRoom.Movie_id)
                    {
                        Movies.Add(item);
                    }
                }
            }
        }
     
    }
}
