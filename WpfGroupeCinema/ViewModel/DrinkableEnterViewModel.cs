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
    public class DrinkableEnterViewModel
    {
        private DrinkableEnterView drinkableEnterView;
        private Cinema cinema;

        public DrinkableEnterView DrinkableEnterView
        {
            get { return drinkableEnterView; }
            set { drinkableEnterView = value; }
        }

        public DrinkableEnterViewModel(DrinkableEnterView drinkableEnterView)
        {
            this.drinkableEnterView = drinkableEnterView;
        }

        public DrinkableEnterViewModel(DrinkableEnterView drinkableEnterView, Cinema cinema)
        {
            this.drinkableEnterView = drinkableEnterView;
            this.cinema = cinema;
            this.DrinkableEnterView.cinemaUserControl.Cinema = cinema;
            this.DrinkableEnterView.addItemUserControl.BtnAdd.Click += BtnAdd_Click;
        }

        private async void BtnAdd_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            Cinema cinema = this.cinema;

            Drinkable drinkable = new Drinkable();
            drinkable.Name = this.DrinkableEnterView.addDrinkableUserControl.Name;
            drinkable.Price = Decimal.Parse(this.DrinkableEnterView.addDrinkableUserControl.Price);
            drinkable.Liter = Decimal.Parse(this.DrinkableEnterView.addDrinkableUserControl.Liter);
            drinkable.Number = Int32.Parse(this.DrinkableEnterView.addDrinkableUserControl.Number);
            drinkable.BuyDate = DateTime.Now;
            drinkable.Cinema_id = cinema.Id;

            await Task.Factory.StartNew(() =>
            {
                MySQLManager<Drinkable> manager = new MySQLManager<Drinkable>(DataConnectionResource.LOCALMYQSL);
                manager.Insert(drinkable);
            });
        }
    }
}
