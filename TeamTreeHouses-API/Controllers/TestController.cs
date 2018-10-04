using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Http;
using TeamTreeHouses_API.DataAccess;

namespace TeamTreeHouses_API.Controllers
{
    // در صورت نیاز به دستکاری و غیرفعال کردن
    /*            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
            در فایل - WebApiConfig.cs
            می توان به روش زیر آدرس دهی را انجام داد
*/
    [RoutePrefix("api/test")]
    public class TestController : ApiController
    {
        /*** Public Part ***/
        public class Sample
        {
            public int Id { get; set; }
            public DateTime Date { get; set; }
            public string Description { get; set; }
        }
        public class Expanded : Sample
        {
            public string Title { get; set; }
        }

        public IHttpActionResult Get()
        {
            var lSample = new Sample() { Id = 10, Description = "Test Description", Date = DateTime.Now };
            return Ok(lSample);
        }

        //[Route("api/test/{id}")] //[RoutePrefix("api/test")]
        [Route("{id}")]
        public IHttpActionResult Get(int value)
        {
            return Ok(value);
        }

        //
        public IHttpActionResult Post(int id)
        {
            return Ok(id);
        }

        [HttpGet]
        [Route("ConnectToDb")]
        public IHttpActionResult ConnectToDb()
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<StatesDbContext, Migrations.Configuration>("DefaultConnection"));
            //
            using (var lContext = new StatesDbContext("DefaultConnection"))
                try { return Ok(lContext.Players.Count()); }//end try
                catch (Exception lError) { return StatusCode(HttpStatusCode.InternalServerError); }//end catch
        }

        public IHttpActionResult Post([FromBody] Sample s)
        {
            return Ok(s.Id + 5);
        }

        //[Route("api/test/postExpanded")] //[RoutePrefix("api/test")]
        [Route("postExpanded")]
        public IHttpActionResult Post([FromUri] Expanded e)
        {
            return Ok(e.Id + 10);
        }
    }
}