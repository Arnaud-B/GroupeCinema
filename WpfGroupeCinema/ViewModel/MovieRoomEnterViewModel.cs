using GroupeCinema.Cinema;
using GroupeCinema.Database;
using GroupeCinema.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfGroupeCinema.Views;

namespace WpfGroupeCinema.ViewModel
{
    public class MovieRoomEnterViewModel
    {
        private MovieRoomEnterView movieRoomEnterView;

        public MovieRoomEnterView MovieRoomEnterView
        {
            get { return movieRoomEnterView; }
            set { movieRoomEnterView = value; }
        }
        public MovieRoomEnterViewModel(MovieRoomEnterView movieRoomEnterView)
        {
            this.movieRoomEnterView = movieRoomEnterView;
        }
        public MovieRoomEnterViewModel(MovieRoomEnterView movieRoomEnterView, Cinema cinema)
        {
            this.movieRoomEnterView = movieRoomEnterView;
            SetupMovieRoomList(cinema);
        }
        private async void SetupMovieRoomList(Cinema cinema)
        {
            List<Movie> results = new List<Movie>();
            await Task.Factory.StartNew(() =>
            {
                MySQLManager<Movie> manager = new MySQLManager<Movie>(DataConnectionResource.LOCALMYQSL);
                results = manager.Get().Result as List<Movie>;
            });

            List<MovieRoom> movieRooms = new List<MovieRoom>();
            await Task.Factory.StartNew(() =>
            {
                MySQLManager<MovieRoom> manager = new MySQLManager<MovieRoom>(DataConnectionResource.LOCALMYQSL);
                movieRooms = manager.Get().Result as List<MovieRoom>;
            });

            List<MovieRoom> tmp = new List<MovieRoom>();
            foreach(var movieRoom in movieRooms)
            {
                if(movieRoom.Cinema_id == cinema.Id)
                {
                    tmp.Add(movieRoom);
                }
            }
         
            Console.WriteLine(results.Count);
            if (results != null && tmp != null)
            {
                this.movieRoomEnterView.movieListUserControl.LoadItems(results, tmp);
            }

        }
    }
}
