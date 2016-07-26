using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroupeCinema.Cinema
{
    [Table("drinkable")]
    public class Drinkable : Product
    {
        #region Attributes
        private Decimal liter;
        #endregion

        #region Properties
        [Column("liter")]
        public Decimal Liter
        {
            get { return liter; }
            set { liter = value;
                this.OnPropertyChanged("Liter");
            }
        }
        #endregion

        #region Constructors
        public Drinkable()
        {

        }
        #endregion
    }
}
