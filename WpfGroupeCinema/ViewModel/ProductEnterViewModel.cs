using GroupeCinema.Cinema;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfGroupeCinema.Views;

namespace WpfGroupeCinema.ViewModel
{
    public class ProductEnterViewModel
    {
        private ProductEnterView productEnterView;

        public ProductEnterView ProductEnterView
        {
            get { return productEnterView; }
            set { productEnterView = value; }
        }

        public ProductEnterViewModel(ProductEnterView productEnterView)
        {
            this.productEnterView = productEnterView;
        }

        public ProductEnterViewModel(Cinema cinema)
        {
            //this.productEnterView = productEnterView;
        }

    }
}
