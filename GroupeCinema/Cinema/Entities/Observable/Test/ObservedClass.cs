using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroupeCinema.Cinema.Entities
{
    public class ObservedClass : Observable
    {
        private int id;
        private String name;


        public int Id
        {
            get { return id; }
            set { id = value; }
        }

       
        public String Name
        {
            get { return name; }
            set { name = value; }
        }


    }
}
