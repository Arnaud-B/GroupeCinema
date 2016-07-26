using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GroupeCinema.Cinema;
using WpfGroupeCinema.Views;
using GroupeCinema.Enums;
using GroupeCinema.Database;

namespace WpfGroupeCinema.ViewModel
{
    public class HomeCinemaEnterViewModel
    {
        private HomeCinemaEnterView homeCinemaEnterView;
        private Cinema cinemaChoose;

        public HomeCinemaEnterView HomeCinemaEnterView
        {
            get { return homeCinemaEnterView; }
            set { homeCinemaEnterView = value; }
        }

        public HomeCinemaEnterViewModel(HomeCinemaEnterView homeCinemaEnterView)
        {
            this.homeCinemaEnterView = homeCinemaEnterView;
            this.HomeCinemaEnterView.cinemaUserControl.Cinema = setUpCinema();
            //this.HomeCinemaEnterView.cinemaUserControl = homeCinemaEnterView;
            //this.HomeCinemaEnterView.myBtn.Click += MyBtn_Click;
        }

        public HomeCinemaEnterViewModel(Cinema cinema)
        {
            Console.WriteLine(cinema.Name);
            setUpCinemaChoose(cinema);

           
        }

        private async void setUpCinemaChoose(Cinema cinema)
        {
            Cinema results = new Cinema();
            await Task.Factory.StartNew(() =>
            {
                MySQLManager<Cinema> manager = new MySQLManager<Cinema>(DataConnectionResource.LOCALMYQSL);
                results = manager.Get(cinema.Id).Result as Cinema;
            });

            if(results != null)
            {
                Console.WriteLine("Id cinema");
                this.homeCinemaEnterView = homeCinemaEnterView;
                this.HomeCinemaEnterView.cinemaUserControl.Cinema = setUpCinema();
            }
        }

        private Cinema setUpCinema()
        {
            GroupeCinema.Cinema.Cinema cinema = new GroupeCinema.Cinema.Cinema();
            cinema.Id = 1;
            cinema.Name = "Gaumont Paris";
            cinema.Finance = 300000;
            return cinema;
        }
    }
}
