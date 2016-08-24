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


       
    }
}
