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

        public AddProductEnterView AddProductEnterView
        {
            get { return addProductEnterView; }
            set { addProductEnterView = value; }
        }
        public AddProductEnterViewModel(AddProductEnterView addProductEnterView)
        {
            this.addProductEnterView = addProductEnterView;
        }


    }
}
