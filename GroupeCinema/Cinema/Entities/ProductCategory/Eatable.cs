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
        private Decimal weight;
        #endregion

        #region Properties
        public Decimal Weight
        {
            get
            {
                return this.weight;
            }

            set
            {
                this.weight = value;
                this.OnPropertyChanged("Weight");
            }
        }
        #endregion

        #region Constructors
        public Eatable()
        {

        }
        #endregion
    }
}
