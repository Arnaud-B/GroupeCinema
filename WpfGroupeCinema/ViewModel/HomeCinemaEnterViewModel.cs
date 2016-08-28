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
        }

        public HomeCinemaEnterViewModel(Cinema cinema)
        {
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


            if (results != null)
            {
                this.homeCinemaEnterView = homeCinemaEnterView;
            }
        }
    }
}
