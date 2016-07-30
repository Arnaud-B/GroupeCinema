using GroupeCinema.MyFaker;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
//using System.Threading.Tasks;

namespace GroupeCinema.Cinema
{

    public abstract class User : EntityBase
    {
        #region Attributes
        private String firstname;
        private String lastname;
        private DateTime birthDate;
        private Int32 address_id;
        private Int32 cinema_id;
        #endregion

        #region Properties
        /// <summary>
        /// Firstname of a user.
        /// </summary>
        //[Column("firstname")]
        public String Firstname
        {
            get
            {
                return this.firstname;
            }

            set
            {
                this.firstname = value;
                this.OnPropertyChanged("Name");
            }
        }

        /// <summary>
        /// Lastname of a user
        /// </summary>
        //[Column("lastname")]
        public String Lastname
        {
            get
            {
                return this.lastname;
            }

            set
            {
                this.lastname = value;
                this.OnPropertyChanged("Lastname");
            }
        }
        /// <summary>
        /// Define the birthDate of User.
        /// </summary>
        //[Column("birthdate")]
        public DateTime BirthDate
        {
            get
            {
                return birthDate;
            }

            set
            {
                birthDate = value;
                this.OnPropertyChanged("BirthDate");
            }
        }
        /// <summary>
        /// Define the address of User.
        /// </summary>
        public Int32 Address_id
        {
            get { return address_id; }
            set
            {
                address_id = value;
                this.OnPropertyChanged("Address_id");
            }
        }
        public Int32 Cinema_id
        {
            get { return cinema_id; }
            set
            {
                cinema_id = value;
                this.OnPropertyChanged("Cinema_id");
            }
        }
        #endregion

        #region Constructors
        public User()
        {

        }
        #endregion

        #region Methods
        public override string ToString()
        {
            return this.firstname + " " + this.lastname + " " + this.address_id;
        }
        #endregion


     

    }
}
