using CinemaAPI.Controllers.Base;
using GroupeCinema.Cinema;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace CinemaAPI.Controllers
{
   
    public class Eatableontroller : BaseController<Eatable>
    {
        [Route("api/Eatables")]
        public override Task<IHttpActionResult> Post(IEnumerable<Eatable> values)
        {
            return base.Post(values);
        }

        [Route("api/Eatables")]
        public override Task<IHttpActionResult> Put(IEnumerable<Eatable> values)
        {
            return base.Put(values);
        }

        [Route("api/Eatables")]
        public override Task<IHttpActionResult> Delete(IEnumerable<Eatable> values)
        {
            return base.Delete(values);
        }
    }
    
}