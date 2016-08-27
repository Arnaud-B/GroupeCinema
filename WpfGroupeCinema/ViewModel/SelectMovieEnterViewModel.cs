using GroupeCinema.Cinema;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfGroupeCinema.Views;
using System.Windows;
using System.Text.RegularExpressions;
using GroupeCinema.Database;
using GroupeCinema.Enums;

namespace WpfGroupeCinema.ViewModel
{
    public class SelectMovieEnterViewModel
    {
        private SelectMovieEnterView selectMovieEnterView;
        private Cinema cinema;
        private Room room;
        private Movie movie;
        private MovieRoom movieRoom;
        
        public SelectMovieEnterView SelectMovieEnterView
        {
            get { return selectMovieEnterView; }
            set { selectMovieEnterView = value; }
        }

        public SelectMovieEnterViewModel(SelectMovieEnterView selectMovieEnterView)
        {
            this.selectMovieEnterView = selectMovieEnterView;
        }

        public SelectMovieEnterViewModel(SelectMovieEnterView selectMovieEnterView, Cinema cinema, Movie movie, MovieRoom movieRoom)
        {
            this.selectMovieEnterView = selectMovieEnterView;
            this.cinema = cinema;
            this.movie = movie;
            this.movieRoom = movieRoom;

            this.selectMovieEnterView.roomListUserControl.roomsListView.SelectionChanged += RoomListView_SelectionChanged;

            this.selectMovieEnterView.updateItemUserControl.BtnUpdate.Click += BtnUpdate_Click;
            this.selectMovieEnterView.updateItemUserControl.BtnDelete.Click += BtnDelete_Click;

            SetupRoomList(cinema);
        }

        private async void BtnUpdate_Click(object sender, RoutedEventArgs e)
        {
            Cinema cinema = this.cinema;
            Movie movie = this.movie;
            MovieRoom movieRoom = this.movieRoom;

            if (Regex.IsMatch(this.selectMovieEnterView.updateMovieUserControl.Length, @"^\d+$"))
            {
                if (Regex.IsMatch(this.selectMovieEnterView.updateMovieUserControl.RentTime, @"^\d+$"))
                {
                    movie.Name = this.selectMovieEnterView.updateMovieUserControl.Name;
                    movie.Author = this.selectMovieEnterView.updateMovieUserControl.Author;
                    movie.Length = Int32.Parse(this.selectMovieEnterView.updateMovieUserControl.Length);
                    movie.ReleaseDate = DateTime.Now;

                    await Task.Factory.StartNew(() =>
                    {
                        MySQLManager<Movie> manager = new MySQLManager<Movie>(DataConnectionResource.LOCALMYQSL);
                        manager.Update(movie);
                    });


                    movieRoom.RentTime = Int32.Parse(this.selectMovieEnterView.updateMovieUserControl.RentTime);
                    movieRoom.Movie_id = movie.Id;
                    movieRoom.Room_id = this.movieRoom.Room_id;
                    if (this.room != null)
                    {
                        movieRoom.Room_id = this.room.Id;
                    }
                    
                    movieRoom.Cinema_id = this.cinema.Id;
                    movieRoom.StartDate = DateTime.Now;
                    await Task.Factory.StartNew(() =>
                    {
                        MySQLManager<MovieRoom> manager1 = new MySQLManager<MovieRoom>(DataConnectionResource.LOCALMYQSL);
                        manager1.Update(movieRoom);
                    });

                    Success(movie.Name, this.movieRoom.Room_id);
                }
                else
                {
                    Fail(1);
                }
            }
            else
            {
                Fail(2);
            }       
        }

        

        private void RoomListView_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            if ((Room)e.AddedItems[0] != null)
            {
                Room room = new Room();
                room = (Room)e.AddedItems[0];
                this.room = room;
            }
        }

        private async void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            Movie movie = this.movie;
            MovieRoom movieRoom = this.movieRoom;

            await Task.Factory.StartNew(() =>
            {
                MySQLManager<Movie> manager = new MySQLManager<Movie>(DataConnectionResource.LOCALMYQSL);
                manager.Delete(movie);
            });

            await Task.Factory.StartNew(() =>
            {
                MySQLManager<MovieRoom> manager1 = new MySQLManager<MovieRoom>(DataConnectionResource.LOCALMYQSL);
                manager1.Delete(movieRoom);
            });
            SuccessDelete(movie.Name);
        }

        private async void SetupRoomList(Cinema cinema)
        {
            List<Room> results = new List<Room>();
            await Task.Factory.StartNew(() =>
            {
                MySQLManager<Room> manager5 = new MySQLManager<Room>(DataConnectionResource.LOCALMYQSL);
                results = manager5.Get().Result as List<Room>;

            });

            if (results != null)
            {
                this.SelectMovieEnterView.roomListUserControl.LoadItems(results, cinema);
            }

        }

        private void Success(String name, Int32 number)
        {
            MessageBoxResult result = MessageBox.Show("Your movie " + name + " has been updated and assigned to room " + number, "GroupeCinema");
        }
        private void SuccessDelete(String name)
        {
            MessageBoxResult result = MessageBox.Show("Your movie " + name + " has been deleted", "GroupeCinema");
        }


        private void Fail(int n)
        {
            String name = "";
            if (n == 1)
            {
                name = "rentTime";
            }
            else
            {
                name = "length";
            }
            MessageBoxResult result = MessageBox.Show("Wrong syntax for field : " + name, "GroupeCinema");
        }
    }
}
