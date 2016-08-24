using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroupeCinema.Cinema
{
    [Table("cinema")]
    public class Cinema : EntityBase
    {
        #region Attributes
        private String name;
        private Decimal finance;
        private Decimal credit;
        private Int32 address_id;
        #endregion

        #region Properties
        [Column("credit")]
        public Decimal Credit
        {
            get
            {
                return this.credit;
            }

            set
            {
                this.credit = value;
                this.OnPropertyChanged("Credit");
            }
        }

        /// <summary>
        /// Money shop have to buy product, won from client.
        /// </summary>
        [Column("finance")]
        public Decimal Finance
        {
            get
            {
                return this.finance;
            }

            set
            {
                this.finance = value;
                this.OnPropertyChanged("Finance");
            }
        }

        /// <summary>
        /// Name of the shop.
        /// </summary>
        [Column("name")]
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

        [Column("address_id")]
        public Int32 Address_id
        {
            get { return address_id; }
            set
            {
                address_id = value;
                this.OnPropertyChanged("Address_id");
            }
        }
        #endregion

        #region Constructors
        public Cinema()
        {
        }
        #endregion

        #region Methods
        #endregion
    }
}
