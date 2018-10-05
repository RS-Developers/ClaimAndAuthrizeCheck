using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TeamTreeHouses_API.DataAccess;
using TeamTreeHouses_API.DataAccess.Entities;
using TeamTreeHouses_API.Filters;
using TeamTreeHouses_API.Models;

namespace TeamTreeHouses_API.Controllers
{
    public class PlayerController : ApiController
    {
        private IModelFactory _lModelFactory;
        private IStateService _lService = null;

        public IHttpActionResult Get()
        {
            try
            {
                var lPlayers = _lService.Players.Get();
                var lModels = lPlayers.Select(_lModelFactory.Create);
                return Ok(lModels);
            }//end try
            catch (Exception lError)
            {
                //Logging
                return InternalServerError(lError);
            }//end catch
        }

        public IHttpActionResult Get(int id)
        {
            try
            {
                var lPlayer = _lService.Players.Get(id);
                var lModel = _lModelFactory.Create(lPlayer);
                return Ok(lModel);
            }//end try
            catch (Exception lError)
            {
                //Logging
                return InternalServerError(lError);
            }//end catch
        }

        public IHttpActionResult Put([FromBody] PlayerModel player)
        {
            try
            {
                var lPlayerEntity = _lModelFactory.Create(player);
                var lPlayer = _lService.Players.Update(lPlayerEntity);
                //
                var lModel = _lModelFactory.Create(lPlayer);
                return Ok(lModel);
            }//end try
            catch (Exception lError)
            {
                //Logging
                return InternalServerError(lError);
            }//end catch
        }

        [ModelValidator]
        public IHttpActionResult Post([FromBody] PlayerModel player)
        {
            try
            {
                var lPlayer = _lModelFactory.Create(player);
                lPlayer = _lService.Players.Insert(lPlayer);
                return Created(string.Format("http://localhost:52699/api/player/{0}", lPlayer.Id), _lModelFactory.Create(lPlayer));
            }//end try
            catch (Exception lError)
            {
                //Logging
                return InternalServerError(lError);
            }//end catch
        }
        //
        public PlayerController()
        {
            _lService = new StateService(new StatesDbContext());
            _lModelFactory = new ModelFactory();
        }
        public PlayerController(IStateService service)
        {
            _lService = service;
        }
    }
}
