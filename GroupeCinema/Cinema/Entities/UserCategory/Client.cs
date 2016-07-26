using GroupeCinema.Enums;
using GroupeCinema.MyFaker;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroupeCinema.Cinema
{
    [Table("client")]
    public class Client : User
    {
        #region Attributes
        private Decimal money;
        //private List<Movie> movies;
        #endregion

        #region Properties
        /// <summary>
        /// Money client have to buy stuff.
        /// </summary>
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
        public Client()
        {   

        }
        #endregion

        #region Methods
        public new List<Client> LoadMultipleItems()
        {
            List<Client> result = new List<Client>();
            for (int i = 0; i < Faker.Number.RandomNumber(200, 201); i++)
            {
                result.Add(LoadSingleItem());
            }
            return result;
        }

        public Client LoadSingleItem()
        {
            Client result = new Client();
            result.Id = Faker.Number.RandomNumber();
            result.Firstname = Faker.Name.FirstName();
            result.Lastname = Faker.Name.FullName();
            //result.Money = Faker.Number.RandomNumber();
            return result;
        }
        #endregion



    }
}
