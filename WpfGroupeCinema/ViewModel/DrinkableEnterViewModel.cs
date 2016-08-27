using GroupeCinema.Cinema;
using GroupeCinema.Database;
using GroupeCinema.Enums;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
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
            if (Regex.IsMatch(this.DrinkableEnterView.addDrinkableUserControl.Price, @"[\d]{1,4}([.,][\d]{1,2})?"))
            {
                if (Regex.IsMatch(this.DrinkableEnterView.addDrinkableUserControl.Liter, @"[\d]{1,4}([.,][\d]{1,2})?"))
                {
                    if (Regex.IsMatch(this.DrinkableEnterView.addDrinkableUserControl.Number, @"[\d]{1,4}([.,][\d]{1,2})?"))
                    {

                        Drinkable drinkable = new Drinkable();
                        drinkable.Name = this.DrinkableEnterView.addDrinkableUserControl.Name;
                        drinkable.Price = Decimal.Parse(this.DrinkableEnterView.addDrinkableUserControl.Price, CultureInfo.InvariantCulture);
                        drinkable.Liter = Decimal.Parse(this.DrinkableEnterView.addDrinkableUserControl.Liter, CultureInfo.InvariantCulture);
                        drinkable.Number = Int32.Parse(this.DrinkableEnterView.addDrinkableUserControl.Number, CultureInfo.InvariantCulture);
                        drinkable.BuyDate = DateTime.Now;
                        drinkable.Cinema_id = cinema.Id;

                        await Task.Factory.StartNew(() =>
                        {
                            MySQLManager<Drinkable> manager = new MySQLManager<Drinkable>(DataConnectionResource.LOCALMYQSL);
                            manager.Insert(drinkable);
                        });
                        Success(drinkable.Name);
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
            else
            {
                Fail(3);
            }
        }

        private void Fail(int n)
        {
            String name = "";
            if (n == 1)
            {
                name = "number";
            }
            else if(n == 2)
            {
                name = "liter";
            }
            else
            {
                name = "price";
            }
            MessageBoxResult result = MessageBox.Show("Wrong syntax for field : " + name, "GroupeCinema");
        }

        private void Success(String name)
        {
            MessageBoxResult result = MessageBox.Show("Your drinkable product " + name + " has been add", "GroupeCinema");
        }

    }
}
