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
    public class ManagementEnterViewModel
    {
        private ManagementEnterView managementEnterView;

        public ManagementEnterView ManagementEnterView
        {
            get { return managementEnterView; }
            set { managementEnterView = value; }
        }

        public ManagementEnterViewModel(ManagementEnterView managementEnterView)
        {
            this.managementEnterView = managementEnterView;
        }

        public ManagementEnterViewModel(ManagementEnterView managementEnterView, Cinema cinema)
        {
            this.managementEnterView = managementEnterView;
            this.ManagementEnterView.cinemaUserControl.Cinema = cinema;
            this.ManagementEnterView.managementCinemaUserControl.Cinema = cinema;

            numberMovie(cinema);
            numberProduct(cinema);
        }

        private async void numberProduct(Cinema cinema)
        {

            List<Eatable> resultsEat = new List<Eatable>();
            await Task.Factory.StartNew(() =>
            {
                MySQLManager<Eatable> manager5 = new MySQLManager<Eatable>(DataConnectionResource.LOCALMYQSL);
                resultsEat = manager5.Get().Result as List<Eatable>;

            });
            List<Eatable> tmpEat = new List<Eatable>();
            foreach (var eat in resultsEat)
            {
                if (eat.Cinema_id == cinema.Id)
                {
                    tmpEat.Add(eat);
                }
            }
            this.ManagementEnterView.productManagementUserControl.numberEatableTxtB.Text = Convert.ToString(tmpEat.Count);



            List<Drinkable> resultsDrink = new List<Drinkable>();
            await Task.Factory.StartNew(() =>
            {
                MySQLManager<Drinkable> manager5 = new MySQLManager<Drinkable>(DataConnectionResource.LOCALMYQSL);
                resultsDrink = manager5.Get().Result as List<Drinkable>;

            });
            List<Drinkable> tmpDrink = new List<Drinkable>();
            foreach (var drink in resultsDrink)
            {
                if (drink.Cinema_id == cinema.Id)
                {
                    tmpDrink.Add(drink);
                }
            }
            this.ManagementEnterView.productManagementUserControl.numberDrinkableTxtB.Text = Convert.ToString(tmpDrink.Count);

            int results = tmpDrink.Count + tmpEat.Count;

            this.ManagementEnterView.productManagementUserControl.numberProductTxtB.Text = Convert.ToString(results);
        }

        private async void numberMovie(Cinema cinema)
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
            foreach (var movieRoom in movieRooms)
            {
                if (movieRoom.Cinema_id == cinema.Id)
                {
                    tmp.Add(movieRoom);
                }
            }

            Console.WriteLine(results.Count);
            if (results != null && tmp != null)
            {

                this.ManagementEnterView.movieCinemaUserControl.numberMovieTxtB.Text = Convert.ToString(results.Count);
            }
        }

        
    }
}
