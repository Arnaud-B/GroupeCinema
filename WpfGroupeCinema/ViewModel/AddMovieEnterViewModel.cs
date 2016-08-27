using GroupeCinema.Cinema;
using GroupeCinema.Database;
using GroupeCinema.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
            this.cinema = cinema;
            this.addMovieEnterView = addMovieEnterView;

            this.AddMovieEnterView.roomListUserControl.roomsListView.SelectionChanged += RoomListView_SelectionChanged;

            this.AddMovieEnterView.addItemUserControl.BtnAdd.Click += BtnAdd_Click;

            SetupRoomList(cinema);
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

        private async void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            Cinema cinema = this.cinema;

            if (Regex.IsMatch(this.AddMovieEnterView.addMovieUserControl.Length, @"^\d+$")) 
            {
                if (Regex.IsMatch(this.AddMovieEnterView.addMovieUserControl.RentTime, @"^\d+$"))
                {
                    Movie movie = new Movie();
                    movie.Name = this.AddMovieEnterView.addMovieUserControl.Name;
                    movie.Author = this.AddMovieEnterView.addMovieUserControl.Author;
                    movie.Length = Int32.Parse(this.AddMovieEnterView.addMovieUserControl.Length);
                    movie.ReleaseDate = DateTime.Now;

                    await Task.Factory.StartNew(() =>
                    {
                        MySQLManager<Movie> manager = new MySQLManager<Movie>(DataConnectionResource.LOCALMYQSL);
                        manager.Insert(movie);
                    });

                    if (this.room != null)
                    {
                        MovieRoom movieRoom = new MovieRoom();
                        movieRoom.RentTime = Int32.Parse(this.AddMovieEnterView.addMovieUserControl.RentTime);
                        movieRoom.Movie_id = movie.Id;
                        movieRoom.Room_id = this.room.Id;
                        movieRoom.Cinema_id = this.cinema.Id;
                        movieRoom.StartDate = DateTime.Now;
                        await Task.Factory.StartNew(() =>
                        {
                            MySQLManager<MovieRoom> manager1 = new MySQLManager<MovieRoom>(DataConnectionResource.LOCALMYQSL);
                            manager1.Insert(movieRoom);
                        });

                        Success(movie.Name, this.room.Number);
                    }
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

        private void Success(String name, Int32 number)
        {
            MessageBoxResult result = MessageBox.Show("Your movie " + name + " has been add and assigned to room "+number, "GroupeCinema");
        }

        private void Fail(int n)
        {
            String name = "";
            if(n == 1)
            {
                name = "rentTime";
            }
            else
            {
                name = "length";
            }
            MessageBoxResult result = MessageBox.Show("Wrong syntax for field : "+name, "GroupeCinema");
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
                this.AddMovieEnterView.roomListUserControl.LoadItems(results, cinema);
            }

        }

    }
}
