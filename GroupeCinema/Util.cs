using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroupeCinema
{
    class Util
    {
        public void Method1<T>(T param) where T : class
        {
            Console.WriteLine(param.ToString());
        }
    }
}
