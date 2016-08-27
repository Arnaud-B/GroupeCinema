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
    public class SelectDrinkableEnterViewModel
    {
        private SelectDrinkableEnterView selectDrinkableEnterView;
        private Drinkable drinkable;
        private Cinema cinema;

        public SelectDrinkableEnterView SelectDrinkableEnterView
        {
            get { return selectDrinkableEnterView; }
            set { selectDrinkableEnterView = value; }
        }

        public SelectDrinkableEnterViewModel(SelectDrinkableEnterView selectDrinkableEnterView)
        {
            this.selectDrinkableEnterView = selectDrinkableEnterView;
        }

        public SelectDrinkableEnterViewModel(SelectDrinkableEnterView selectDrinkableEnterView, Cinema cinema, Drinkable drinkable)
        {
            this.selectDrinkableEnterView = selectDrinkableEnterView;
            this.cinema = cinema;
            this.drinkable = drinkable;
            this.selectDrinkableEnterView.updateItemUserControl.BtnUpdate.Click += BtnUpdate_Click;
            this.selectDrinkableEnterView.updateItemUserControl.BtnDelete.Click += BtnDelete_Click;
        }

        private async void BtnUpdate_Click(object sender, RoutedEventArgs e)
        {
            Drinkable drinkable = this.drinkable;
            Cinema cinema = this.cinema;
            if (Regex.IsMatch(this.selectDrinkableEnterView.updateDrinkableUserControl.Price, @"[\d]{1,4}([.,][\d]{1,2})?"))
            {
                if (Regex.IsMatch(this.selectDrinkableEnterView.updateDrinkableUserControl.Liter, @"[\d]{1,4}([.,][\d]{1,2})?"))
                {
                    if (Regex.IsMatch(this.selectDrinkableEnterView.updateDrinkableUserControl.Number, @"[\d]{1,4}([.,][\d]{1,2})?"))
                    {
                        drinkable.Name = this.selectDrinkableEnterView.updateDrinkableUserControl.Name;
                        drinkable.Price = Decimal.Parse(this.SelectDrinkableEnterView.updateDrinkableUserControl.Price, CultureInfo.InvariantCulture);
                        drinkable.Liter = Decimal.Parse(this.selectDrinkableEnterView.updateDrinkableUserControl.Liter, CultureInfo.InvariantCulture);
                        drinkable.Number = Int32.Parse(this.selectDrinkableEnterView.updateDrinkableUserControl.Number, CultureInfo.InvariantCulture);
                        drinkable.BuyDate = DateTime.Now;
                        drinkable.Cinema_id = cinema.Id;

                        /*await Task.Factory.StartNew(() =>
                        {
                            WebServiceManager<Eatable> manager1 = new WebServiceManager<Eatable>(DataConnectionResource.LOCALAPI);
                            manager1.Post(eatable);
                        });*/

                        await Task.Factory.StartNew(() =>
                        {
                            MySQLManager<Drinkable> manager = new MySQLManager<Drinkable>(DataConnectionResource.LOCALMYQSL);
                            manager.Update(drinkable);
                        });
                        Console.WriteLine(drinkable.Price);
                        Console.WriteLine(drinkable.Liter);
                        Console.WriteLine(drinkable.Number);
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

        private async void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            Drinkable drinkable = this.drinkable;
            await Task.Factory.StartNew(() =>
            {
                MySQLManager<Drinkable> manager = new MySQLManager<Drinkable>(DataConnectionResource.LOCALMYQSL);
                manager.Delete(drinkable);
            });
            SuccessDelete(drinkable.Name);
        }

        private void Fail(int n)
        {
            String name = "";
            if (n == 1)
            {
                name = "number";
            }
            else if (n == 2)
            {
                name = "Liter";
            }
            else
            {
                name = "price";
            }
            MessageBoxResult result = MessageBox.Show("Wrong syntax for field : " + name, "GroupeCinema");
        }

        private void Success(String name)
        {
            MessageBoxResult result = MessageBox.Show("Your drinkable product " + name + " has been updated", "GroupeCinema");
        }

        private void SuccessDelete(String name)
        {
            MessageBoxResult result = MessageBox.Show("Your drinkable product " + name + " has been deleted", "GroupeCinema");
        }
    }
}
