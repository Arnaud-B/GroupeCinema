using GroupeCinema.Cinema;
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

        public DrinkableEnterView DrinkableEnterView
        {
            get { return drinkableEnterView; }
            set { drinkableEnterView = value; }
        }

        public DrinkableEnterViewModel(DrinkableEnterView drinkableEnterView)
        {
            this.drinkableEnterView = drinkableEnterView;
        }

        public DrinkableEnterViewModel(Cinema cinema)
        {
            //this.drinkableEnterView = drinkableEnterView;
        }
    }
}
