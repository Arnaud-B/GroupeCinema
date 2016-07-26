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
    public class AddProductEnterViewModel
    {
        private AddProductEnterView addProductEnterView;
        private Cinema cinema;

        public AddProductEnterView AddProductEnterView
        {
            get { return addProductEnterView; }
            set { addProductEnterView = value; }
        }
        public AddProductEnterViewModel(AddProductEnterView addProductEnterView)
        {
            this.addProductEnterView = addProductEnterView;
            //this.AddProductEnterView.cinemaUserControl.Cinema = setUpCinema();
        }

        public AddProductEnterViewModel(Cinema cinema)
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

            if (results != null)
            {
                //this.addProductEnterView = addProductEnterView;
                //this.AddProductEnterView.cinemaUserControl.Cinema = setUpCinema();
            }
        }

    }
}
