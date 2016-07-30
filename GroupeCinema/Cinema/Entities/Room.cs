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
        private Int32 cinema_id;
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
        public Room()
        {

        }
        #endregion

        #region Methods
        #endregion

    }
}
