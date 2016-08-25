using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroupeCinema.Cinema
{
    [Table("movie")]
    public class Movie : EntityBase
    {
        #region Attributes
        private String name;
        private String author;
        private Int32 length;
        private DateTime releaseDate;
        private MovieProvider movieProvider;
        #endregion

        #region Properties
        public MovieProvider MovieProvider
        {
            get
            {
                return this.movieProvider;
            }

            set
            {
                this.movieProvider = value;
                this.OnPropertyChanged("MovieProvidor");
            }
        }
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

        [Column("author")]
        public String Author
        {
            get
            {
                return this.author;
            }

            set
            {
                this.author = value;
                this.OnPropertyChanged("author");
            }
        }

        [Column("length")]
        public Int32 Length
        {
            get
            {
                return this.length;
            }

            set
            {
                this.length = value;
                this.OnPropertyChanged("Length");
            }
        }
        [Column("releaseDate")]
        public DateTime ReleaseDate
        {
            get
            {
                return releaseDate;
            }

            set
            {
                releaseDate = value;
                this.OnPropertyChanged("ReleaseDate");
            }
        }
        #endregion

        #region Constructors
        public Movie()
        {

        }
        #endregion

        #region Methods
        #endregion



    }
}
