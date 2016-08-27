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
    public class SelectEatableEnterViewModel
    {
        private SelectEatableEnterView selectEatableEnterView;
        private Eatable eatable;
        private Cinema cinema;

        public SelectEatableEnterView SelectEatableEnterView
        {
            get { return selectEatableEnterView; }
            set { selectEatableEnterView = value; }
        }

        public SelectEatableEnterViewModel(SelectEatableEnterView selectEatableEnterView)
        {
            this.selectEatableEnterView = selectEatableEnterView;
        }

        public SelectEatableEnterViewModel(SelectEatableEnterView selectEatableEnterView, Cinema cinema, Eatable eatable)
        {
            this.selectEatableEnterView = selectEatableEnterView;
            this.cinema = cinema;
            this.eatable = eatable;
            this.selectEatableEnterView.updateItemUserControl.BtnUpdate.Click += BtnUpdate_Click;
            this.selectEatableEnterView.updateItemUserControl.BtnDelete.Click += BtnDelete_Click;
        }

        private async void BtnUpdate_Click(object sender, RoutedEventArgs e)
        {

            Eatable eatable = this.eatable;
            Cinema cinema = this.cinema;
            if (Regex.IsMatch(this.selectEatableEnterView.updateEatableUserControl.Price, @"[\d]{1,4}([.,][\d]{1,2})?"))
            {
                if (Regex.IsMatch(this.selectEatableEnterView.updateEatableUserControl.Weight, @"[\d]{1,4}([.,][\d]{1,2})?"))
                {
                    if (Regex.IsMatch(this.selectEatableEnterView.updateEatableUserControl.Number, @"[\d]{1,4}([.,][\d]{1,2})?"))
                    {
                        eatable.Name = this.selectEatableEnterView.updateEatableUserControl.eatableNameTxtB.Text;
                        eatable.Price = Decimal.Parse(this.selectEatableEnterView.updateEatableUserControl.eatablePriceTxtB.Text, CultureInfo.InvariantCulture);
                        eatable.Weight = Decimal.Parse(this.selectEatableEnterView.updateEatableUserControl.eatableWeightTxtB.Text, CultureInfo.InvariantCulture);
                        eatable.Number = Int32.Parse(this.selectEatableEnterView.updateEatableUserControl.eatableNumberTxtB.Text, CultureInfo.InvariantCulture);
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
                            manager.Update(eatable);
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

        private async void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            Eatable eatable = this.eatable;
            await Task.Factory.StartNew(() =>
            {
                MySQLManager<Eatable> manager = new MySQLManager<Eatable>(DataConnectionResource.LOCALMYQSL);
                manager.Delete(eatable);
            });
            SuccessDelete(eatable.Name);
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
            MessageBoxResult result = MessageBox.Show("Your eatable product " + name + " has been updated", "GroupeCinema");
        }

        private void SuccessDelete(String name)
        {
            MessageBoxResult result = MessageBox.Show("Your eatable product " + name + " has been deleted", "GroupeCinema");
        }

    }
}
