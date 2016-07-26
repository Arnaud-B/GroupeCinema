using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroupeCinema.Cinema
{
    [Table("Address")]
    public class Address : EntityBase
    {
        #region Attributes
        private Int32 number;
        private String path;
        private String street;
        private String city;
        #endregion

        #region Properties
        /// <summary>
        /// Path type ("rue", "avenue", "chemin").
        /// </summary>
        [Column("path")]
        public String Path
        {
            get { return path; }
            set
            {
                path = value;
                this.OnPropertyChanged("Path");
            }
        }
        /// <summary>
        /// Number of the address.
        /// </summary>
        [Column("number")]
        public Int32 Number
        {
            get { return number; }
            set
            {
                number = value;
                this.OnPropertyChanged("Number");
            }
        }
        /// <summary>
        /// Name of the way.
        /// </summary>
        [Column("street")]
        public String Street
        {
            get { return street; }
            set
            {
                street = value;
                this.OnPropertyChanged("Street");
            }
        }
        /// <summary>
        /// City name.
        /// </summary>
        [Column("city")]
        public String City
        {
            get { return city; }
            set
            {
                city = value;
                this.OnPropertyChanged("City");
            }
        }
        #endregion

        #region Constructors
        public Address()
        {

        }
        #endregion

        #region Methods
        public override string ToString()
        {
            return this.number + " " + this.path + " " + this.street + " " + this.city;
        }
        #endregion

    }
}
