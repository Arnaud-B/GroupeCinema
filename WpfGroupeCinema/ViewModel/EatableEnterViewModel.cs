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

            Eatable eatable = new Eatable();
            eatable.Name = this.EatableEnterView.addEatableUserControl.Name;
            eatable.Price = Decimal.Parse(this.EatableEnterView.addEatableUserControl.Price);
            eatable.Weight = Decimal.Parse(this.EatableEnterView.addEatableUserControl.Weight);
            eatable.Number = Int32.Parse(this.EatableEnterView.addEatableUserControl.Number);
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


        }

    }
}
