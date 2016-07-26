using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroupeCinema.Cinema
{
    [Table("productProvider")]
    public class ProductProvider : Provider
    {
        #region Attributes
        private List<Eatable> eatables;
        private List<Drinkable> drinkables;
        #endregion

        #region Properties
        public List<Drinkable> Drinkables
        {
            get { return drinkables; }
            set
            {
                drinkables = value;
                this.OnPropertyChanged("drinkables");
            }
        }
        public List<Eatable> Eatables
        {
            get { return eatables; }
            set
            {
                eatables = value;
                this.OnPropertyChanged("drinkables");
            }
        }
        #endregion

        #region Constructor
        public ProductProvider()
        {

        }
        #endregion

        #region Methods
        #endregion
    }
}
