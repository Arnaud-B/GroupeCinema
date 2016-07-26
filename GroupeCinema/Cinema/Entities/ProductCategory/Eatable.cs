using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroupeCinema.Cinema
{
    [Table("eatable")]
    public class Eatable : Product
    {
        #region Attributes
        private Boolean temp;
        //private Cinema cinema;
        #endregion

        #region Properties
        [Column("temp")]
        public Boolean Temp
        {
            get { return temp; }
            set { temp = value;
                this.OnPropertyChanged("Temp");
            }
        }
        /*public Cinema Cinema
        {
            get { return cinema; }
            set
            {
                cinema = value;
                this.OnPropertyChanged("Cinema");
            }
        }*/
        #endregion

        #region Constructors
        public Eatable()
        {

        }
        #endregion
    }
}
