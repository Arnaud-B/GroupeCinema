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
    public class CinemaController : BaseController<Cinema>
    {
        [Route("api/Cinemas")]
        public override Task<IHttpActionResult> Post(IEnumerable<Cinema> values)
        {
            return base.Post(values);
        }

        [Route("api/Cinemas")]
        public override Task<IHttpActionResult> Put(IEnumerable<Cinema> values)
        {
            return base.Put(values);
        }

        [Route("api/Cinemas")]
        public override Task<IHttpActionResult> Delete(IEnumerable<Cinema> values)
        {
            return base.Delete(values);
        }
    }
}
