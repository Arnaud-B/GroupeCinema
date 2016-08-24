using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroupeCinema.Cinema
{
    [Table("movieRoom")]
    public class MovieRoom : EntityBase
    {
        #region Attributes
        private Int32 movie_id;
        private Int32 room_id;
        private Int32 rentTime;
        private DateTime startDate;
        #endregion

        #region Properties
        [Column("movie_id")]
        public Int32 Movie_id
        {
            get { return movie_id; }
            set
            {
                movie_id = value;
                this.OnPropertyChanged("Movie_id");
            }
        }
        [Column("room_id")]
        public Int32 Room_id
        {
            get { return room_id; }
            set
            {
                room_id = value;
                this.OnPropertyChanged("Room_id");

            }
        }
        [Column("rentTime")]
        public Int32 RentTime
        {
            get
            {
                return this.rentTime;
            }

            set
            {
                this.rentTime = value;
                this.OnPropertyChanged("rentTime");
            }
        }
        public DateTime StartDate
        {
            get { return startDate; }
            set
            {
                startDate = value;
                this.OnPropertyChanged("StartDate");
            }
        }
        #endregion

        #region Constructors
        public MovieRoom()
        {

        }
        #endregion
        
        #region Methods
        #endregion

    }
}
