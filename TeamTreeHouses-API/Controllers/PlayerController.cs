using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TeamTreeHouses_API.DataAccess;

namespace TeamTreeHouses_API.Controllers
{
    public class PlayerController : ApiController
    {
        private IStateService _lService = null;

        public IHttpActionResult Get()
        {
            var lPlayers = _lService.Players.Get();
            return Ok(lPlayers);
        }

        //
        public PlayerController()
        {
            _lService = new StateService(new StatesDbContext());
        }
        public PlayerController(IStateService service)
        {
            _lService = service;
        }
    }
}
