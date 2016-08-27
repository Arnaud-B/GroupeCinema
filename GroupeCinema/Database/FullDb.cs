using GroupeCinema.Cinema;
using GroupeCinema.Enums;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace GroupeCinema.Database
{
    [DbConfigurationType(typeof(MySql.Data.Entity.MySqlEFConfiguration))]
    public class FullDb : DbContext
    {

        #region singleton
        private static volatile FullDb instance;
        private static object syncRoot = new Object();

        private FullDb() { }

        public static FullDb Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (syncRoot)
                    {
                        if (instance == null)
                            instance = new FullDb();
                    }
                }

                return instance;
            }
        }
        #endregion

        public DbSet<GroupeCinema.Cinema.Cinema> DbSetCinema { get; set; }

        //public DbSet<Product> DbSetProduct { get; set; }
        public DbSet<Drinkable> DbSetDrinkable { get; set; }
        public DbSet<Eatable> DbSetEatable { get; set; }
        public DbSet<Movie> DbSetMovie { get; set; }
        public DbSet<Room> DbSetRoom { get; set; }
        public DbSet<MovieRoom> DbSetMovieRoom { get; set; }

        // User
        //public DbSet<User> DbSetUser { get; set; }
        public DbSet<Owner> DbSetOwner { get; set; }
        public DbSet<Client> DbSetClient { get; set; }
        public DbSet<Employee> DbSetEmployee { get; set; }

        public DbSet<Address> DbSetAddress { get; set; }

        public FullDb(DataConnectionResource dataConnectionResource) : base(EnumString.GetStringValue(dataConnectionResource))
        {
            //this.Database.Connection.ChangeDatabase(EnumString.GetStringValue(dataConnectionResource));
            this.Database.CreateIfNotExists();
        }





    }
}
