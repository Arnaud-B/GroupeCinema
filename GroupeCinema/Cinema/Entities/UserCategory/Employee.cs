using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroupeCinema.Cinema
{
    [Table("employee")]
    public class Employee : User
    {
        #region Attributes
        //private Cinema cinema;
        #endregion

        #region Properties
        //[ForeignKey("cinema_id")]
        /*public Cinema Cinema
        {
            get
            {
                return cinema;
            }
            set
            {
                cinema = value;
                this.OnPropertyChanged("Cinema");
            }
        }*/

        #endregion

        #region Constructors
        public Employee()
        {

        }
        #endregion

        #region Methods
        public override string ToString()
        {
            return base.ToString();
        }
        #endregion

    }
}
