using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroupeCinema.Cinema.Entities
{
    public class Investor : IInvestor
    {
        private string _name;
        private Object _toSee;
        public Investor(string name)
        {
            this._name = name;
        }
        public void Update(Object toSee)
        {
            // Something internal todo
        }
        public Object toSee
        {
            get { return _toSee; }
            set { _toSee = value; }
        }
    }
}
