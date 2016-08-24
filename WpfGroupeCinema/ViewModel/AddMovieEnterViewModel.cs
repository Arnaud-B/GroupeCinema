using GroupeCinema.Cinema;
using GroupeCinema.Database;
using GroupeCinema.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WpfGroupeCinema.Views;

namespace WpfGroupeCinema.ViewModel
{
    public class AddMovieEnterViewModel
    {
        private AddMovieEnterView addMovieEnterView;
        private Cinema cinema;
        private Room room;

        public AddMovieEnterView AddMovieEnterView
        {
            get { return addMovieEnterView; }
            set { addMovieEnterView = value; }
        }
        public AddMovieEnterViewModel(AddMovieEnterView addMovieEnterView)
        {
            this.addMovieEnterView = addMovieEnterView;
        }

        public AddMovieEnterViewModel(AddMovieEnterView addMovieEnterView, Cinema cinema)
        {
            this.addMovieEnterView = addMovieEnterView;

            this.AddMovieEnterView.roomListUserControl.roomsListView.SelectionChanged += RoomListView_SelectionChanged;

            this.AddMovieEnterView.btnAdd.Click += BtnAdd_Click;

            SetupRoomList(cinema);
        }
        private void RoomListView_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            if ((Room)e.AddedItems[0] != null)
            {
                Room room = new Room();
                room = (Room)e.AddedItems[0];
                this.room = room;
                Console.WriteLine(room.Id);
            }
        }

        private async void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            Cinema cinema = this.cinema;

            Movie movie = new Movie();
            movie.Name = this.AddMovieEnterView.addMovieUserControl.Name;
            movie.Author = this.AddMovieEnterView.addMovieUserControl.Author;
            movie.MovieLength = Int32.Parse(this.AddMovieEnterView.addMovieUserControl.Length);
            movie.ReleaseDate = DateTime.Now;

            await Task.Factory.StartNew(() =>
            {
                MySQLManager<Movie> manager = new MySQLManager<Movie>(DataConnectionResource.LOCALMYQSL);
                manager.Insert(movie);
            });

            if(this.room != null)
            {
                MovieRoom movieRoom = new MovieRoom();
                movieRoom.RentTime = Int32.Parse(this.AddMovieEnterView.addMovieUserControl.RentTime);
                movieRoom.Movie_id = movie.Id;
                movieRoom.Room_id = this.room.Id;
                movieRoom.StartDate = DateTime.Now;
                await Task.Factory.StartNew(() =>
                {
                    MySQLManager<MovieRoom> manager1 = new MySQLManager<MovieRoom>(DataConnectionResource.LOCALMYQSL);
                    manager1.Insert(movieRoom);
                });
            }
        }


        private async void SetupRoomList(Cinema cinema)
        {
            List<Room> results = new List<Room>();
            await Task.Factory.StartNew(() =>
            {
                MySQLManager<Room> manager5 = new MySQLManager<Room>(DataConnectionResource.LOCALMYQSL);
                results = manager5.Get().Result as List<Room>;

            });


            Console.WriteLine(results.Count);
            if (results != null)
            {
                this.AddMovieEnterView.roomListUserControl.LoadItems(results, cinema);
            }

        }

    }
}
