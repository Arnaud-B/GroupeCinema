using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroupeCinema.Cinema
{
    [Table("owner")]
    public class Owner : User
    {
        #region
        private List<Cinema> cinemas;
        private Decimal money;
        #endregion

        #region Properties
        public List<Cinema> Cinemas
        {
            get
            {
                return this.cinemas;
            }

            set
            {
                this.cinemas = value;
                this.OnPropertyChanged("Cinemas");
            }
        }
        [Column("money")]
        public Decimal Money
        {
            get
            {
                return this.money;
            }

            set
            {
                this.money = value;
                this.OnPropertyChanged("Money");
            }
        }
        #endregion

        #region Constructors
        public Owner()
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
