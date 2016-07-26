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
        private Address address;
        /*private List<Eatable> eatables;
        private List<Drinkable> drinkables;*/
        private List<Employee> employees;
        private List<Client> clients;
        private List<Room> rooms;
        //private List<Movie> movies;
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

        //[Column("address_id")]
        public Address Address
        {
            get { return address; }
            set
            {
                address = value;
                this.OnPropertyChanged("Address");
            }
        }

        /*public List<Eatable> Eatables
        {
            get { return eatables; }
            set
            {
                eatables = value;
                this.OnPropertyChanged("Eatables");
            }
        }
        public List<Drinkable> Drinkables
        {
            get { return drinkables; }
            set
            {
                drinkables = value;
                this.OnPropertyChanged("Drinkables");
            }
        }*/

        public List<Employee> Employees
        {
            get { return employees; }
            set
            {
                employees = value;
                this.OnPropertyChanged("Employees");
            }
        }
        public List<Client> Clients
        {
            get { return clients; }
            set
            {
                clients = value;
                this.OnPropertyChanged("Clients");
            }
        }
        public List<Room> Rooms
        {
            get
            {
                return rooms;
            }
            set
            {
                rooms = value;
                this.OnPropertyChanged("Rooms");
            }
        }
        /*public List<Movie> Movies
        {
            get { return movies; }
            set
            {
                movies = value;
                this.OnPropertyChanged("Movies");
            }
        }*/
        #endregion

        #region Constructors
        public Cinema()
        {
            //this.eatables = new List<Eatable>();
            //this.drinkables = new List<Drinkable>();
            this.employees = new List<Employee>();
            this.rooms = new List<Room>();
        }
        #endregion

        #region Methods
        #endregion
    }
}
