using GroupeCinema.Cinema;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfGroupeCinema.Views;

namespace WpfGroupeCinema.ViewModel
{
    public class MovieEnterViewModel
    {
        private MovieEnterView movieEnterView;
        private Cinema cinema;

        public MovieEnterView MovieEnterView
        {
            get { return movieEnterView; }
            set { movieEnterView = value; }
        }

        public MovieEnterViewModel(MovieEnterView movieEnterView)
        {
            this.movieEnterView = movieEnterView;
        }
        public MovieEnterViewModel(Cinema cinema)
        {
            
        }
    }
}
