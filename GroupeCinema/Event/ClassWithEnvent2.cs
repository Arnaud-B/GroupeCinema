using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroupeCinema.Event
{
    public class ClassWithEnvent2
    {
        public event EventHandler Handler;
        public event EventHandler<ClassWithEvent> Handler2;

        public int Id { get; set; }
        public int Name { get; set; }

        public virtual void OnHandler(EventArgs e)
        {
            if (Handler != null)
                Handler(this, e);
        }
    }
}
