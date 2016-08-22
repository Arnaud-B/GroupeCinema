using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroupeCinema.Cinema
{
    
    public abstract class Product : EntityBase
    {
        #region Attributes
        private String name;
        private Decimal price;
        private Int32 number;
        private DateTime buyDate;
        private Int32 cinema_id;
        #endregion

        #region Properties
        /// <summary>
        /// Object name.
        /// </summary>
        public String Name
        {
            get
            {
                return this.name;
            }

            set
            {
                this.name = value;
                this.OnPropertyChanged("Name");
            }
        }

        /// <summary>
        /// Object cost all cost in it.
        /// </summary>
        //[Column("price")]
        public Decimal Price
        {
            get
            {
                return this.price;
            }

            set
            {
                this.price = value;
                this.OnPropertyChanged("Price");
            }
        }
        public Int32 Number
        {
            get
            {
                return this.number;
            }

            set
            {
                this.number = value;
                this.OnPropertyChanged("Number");
            }
        }
        public DateTime BuyDate
        {
            get
            {
                return buyDate;
            }

            set
            {
                buyDate = value;
                this.OnPropertyChanged("BuyDate");
            }
        }
        //[ForeignKey("Cinema")]
        public Int32 Cinema_id
        {
            get
            {
                return this.cinema_id;
            }

            set
            {
                this.cinema_id = value;
                this.OnPropertyChanged("Cinema_id");
            }
        }

        #endregion

        #region Constructors
        public Product()
        {

        }
        #endregion

        #region Methods
        /*public override string ToString()
        {
            return this.name + " " + this.price;
        }*/
        #endregion

    }
}
