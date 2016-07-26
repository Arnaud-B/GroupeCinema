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
        private DateTime buyDate;
        private Cinema cinema;
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
        public Cinema Cinema
        {
            get
            {
                return this.cinema;
            }

            set
            {
                this.cinema = value;
                this.OnPropertyChanged("Cinema");
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
