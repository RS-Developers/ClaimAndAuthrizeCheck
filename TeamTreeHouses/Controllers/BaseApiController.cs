using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace TeamTreeHouses.Controllers
{
    public class BaseApiController : ApiController
    {
        public string UserId => HttpContext.Current.User.Identity.Name;
    }
}
