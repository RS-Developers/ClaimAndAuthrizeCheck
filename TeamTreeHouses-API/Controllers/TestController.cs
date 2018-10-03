using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace TeamTreeHouses_API.Controllers
{
    public class TestController : ApiController
    {
        /*** Public Part ***/
        public class Sample
        {
            public int Id { get; set; }
            public string Description { get; set; }
        }
        public class Expanded : Sample
        {
            public string Title { get; set; }
        }

        public IHttpActionResult Get()
        {
            var lSample = new Sample() { Id = 10, Description = "Test Description" };
            return Ok(lSample);
        }

        public IHttpActionResult Post(int id)
        {
            return Ok(id);
        }

        public IHttpActionResult Post([FromBody] Sample s)
        {
            return Ok(s.Id + 5);
        }

        public IHttpActionResult Post([FromUri] Expanded e)
        {
            return Ok(e.Id + 10);
        }
    }
}