using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroupeCinema.Cinema
{
    [Table("movieProvider")]
    public class MovieProvider : Provider
    {
        #region Attributes
        private List<Movie> movies;
        #endregion

        #region Properties
        public List<Movie> Movies
        {
            get { return movies; }
            set
            {
                movies = value;
                this.OnPropertyChanged("Movies");
            }
        }
        #endregion

        #region Constructors
        public MovieProvider()
        {

        }
        #endregion

        #region Methods
        #endregion
    }
}
