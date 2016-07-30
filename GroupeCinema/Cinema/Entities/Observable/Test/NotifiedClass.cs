using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroupeCinema.Cinema.Entities
{
    public class NotifiedClass
    {
        private int id;
        private Boolean isSTH;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        public Boolean IsSTH
        {
            get { return isSTH; }
            set { isSTH = value; }
        }
       
        public void Update(Object ToSee)
        {
            Console.WriteLine(ToSee);
        }
    }
}
