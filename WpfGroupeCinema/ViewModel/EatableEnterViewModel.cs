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
    public class EatableEnterViewModel
    {
        private EatableEnterView eatableEnterView;
        private Cinema cinema;

        public EatableEnterView EatableEnterView
        {
            get { return eatableEnterView; }
            set { eatableEnterView = value; }
        }

        public EatableEnterViewModel(EatableEnterView eatableEnterView)
        {
            this.eatableEnterView = eatableEnterView;
        }

        public EatableEnterViewModel(EatableEnterView eatableEnterView, Cinema cinema)
        {
            this.eatableEnterView = eatableEnterView;
            this.cinema = cinema;
            this.EatableEnterView.cinemaUserControl.Cinema = cinema;
            this.EatableEnterView.addItemUserControl.BtnAdd.Click += BtnAdd_Click;
        }

        private async void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
         

            Cinema cinema = this.cinema;
            if (Regex.IsMatch(this.EatableEnterView.addEatableUserControl.Price, @"[\d]{1,4}([.,][\d]{1,2})?"))
            {
                if (Regex.IsMatch(this.EatableEnterView.addEatableUserControl.Weight, @"[\d]{1,4}([.,][\d]{1,2})?"))
                {
                    if (Regex.IsMatch(this.EatableEnterView.addEatableUserControl.Number, @"[\d]{1,4}([.,][\d]{1,2})?"))
                    {
                        Eatable eatable = new Eatable();
                        eatable.Name = this.EatableEnterView.addEatableUserControl.Name;
                        eatable.Price = Decimal.Parse(this.EatableEnterView.addEatableUserControl.Price, CultureInfo.InvariantCulture);
                        eatable.Weight = Decimal.Parse(this.EatableEnterView.addEatableUserControl.Weight, CultureInfo.InvariantCulture);
                        eatable.Number = Int32.Parse(this.EatableEnterView.addEatableUserControl.Number, CultureInfo.InvariantCulture);
                        eatable.BuyDate = DateTime.Now;
                        eatable.Cinema_id = cinema.Id;

                        /*await Task.Factory.StartNew(() =>
                        {
                            WebServiceManager<Eatable> manager1 = new WebServiceManager<Eatable>(DataConnectionResource.LOCALAPI);
                            manager1.Post(eatable);
                        });*/

                        await Task.Factory.StartNew(() =>
                        {
                            MySQLManager<Eatable> manager = new MySQLManager<Eatable>(DataConnectionResource.LOCALMYQSL);
                            manager.Insert(eatable);
                        });
                        Success(eatable.Name);
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
            else if (n == 2)
            {
                name = "weight";
            }
            else
            {
                name = "price";
            }
            MessageBoxResult result = MessageBox.Show("Wrong syntax for field : " + name, "GroupeCinema");
        }

        private void Success(String name)
        {
            MessageBoxResult result = MessageBox.Show("Your eatable product "+name+" has been add", "GroupeCinema");
        }

    }
}
