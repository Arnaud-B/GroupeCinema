using GroupeCinema.Cinema;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroupeCinema.Cinema
{
    [Table("room")]
    public class Room : EntityBase
    {
        #region Attributes
        //private Cinema cinema;
        private Int32 capacity;
        #endregion


        #region Properties
        [Column("capacity")]
        public Int32 Capacity
        {
            get
            {
                return capacity;
            }
            set
            {
                capacity = value;
                this.OnPropertyChanged("Capacity");
            }
        }
        //[Column("cinema")]
        /*public Cinema Cinema
        {
            get
            {
                return cinema;
            }
            set
            {
                cinema = value;
                this.OnPropertyChanged("Cinema");
            }
        }*/
        #endregion

        #region Constructors
        public Room()
        {

        }
        #endregion

        #region Methods
        #endregion

    }
}
