using GroupeCinema.Cinema;
using GroupeCinema.Database;
using GroupeCinema.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfGroupeCinema.Views;
using WpfGroupeCinema.Views.Pages;

namespace WpfGroupeCinema.ViewModel
{
    public class ProductGestionEnterViewModel
    {
        private ProductGestionEnterView productGestionEnterView;
        private Cinema cinema;

        public ProductGestionEnterView ProductGestionEnterView
        {
            get { return productGestionEnterView; }
            set { productGestionEnterView = value; }
        }

        public ProductGestionEnterViewModel(ProductGestionEnterView productGestionEnterView)
        {
            this.productGestionEnterView = productGestionEnterView;
        }

        public ProductGestionEnterViewModel(ProductGestionEnterView productGestionEnterView, Cinema cinema)
        {
            this.productGestionEnterView = productGestionEnterView;
            SetupEatableList(cinema);
            SetupDrinkableList(cinema);
        }
        private async void SetupEatableList(Cinema cinema)
        {
            List<Eatable> results = new List<Eatable>();
            await Task.Factory.StartNew(() =>
            {
                MySQLManager<Eatable> manager5 = new MySQLManager<Eatable>(DataConnectionResource.LOCALMYQSL);
                results = manager5.Get().Result as List<Eatable>;

            });

            
            if (results != null)
            {
                this.productGestionEnterView.eatableListUserControl.LoadItems(results, cinema);
            }

        }
        private async void SetupDrinkableList(Cinema cinema)
        {
            List<Drinkable> results = new List<Drinkable>();
            await Task.Factory.StartNew(() =>
            {
                MySQLManager<Drinkable> manager5 = new MySQLManager<Drinkable>(DataConnectionResource.LOCALMYQSL);
                results = manager5.Get().Result as List<Drinkable>;

            });


           
            if (results != null)
            {
                this.productGestionEnterView.drinkableListUserControl.LoadItems(results, cinema);
            }

        }
    }
}
