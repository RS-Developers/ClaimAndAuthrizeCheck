using System;
using System.Linq;
using System.Web.Http;
using TeamTreeHouses_API.DataAccess;
using TeamTreeHouses_API.Models;

namespace TeamTreeHouses_API.Controllers
{
    public class TeamController : ApiController
    {
        private IModelFactory _lModelFactory;
        private IStateService _lService = null;

        public IHttpActionResult Get()
        {
            try
            {
                var lTeams = _lService.Teams.Get();
                var lModels = lTeams.Select(_lModelFactory.Create);
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
                var lTeam = _lService.Teams.Get(id);
                var lModel = _lModelFactory.Create(lTeam);
                return Ok(lModel);
            }//end try
            catch (Exception lError)
            {
                //Logging
                return InternalServerError(lError);
            }//end catch
        }
        //
        public TeamController()
        {
            _lService = new StateService(new StatesDbContext());
            _lModelFactory = new ModelFactory();
        }
        public TeamController(IStateService service)
        {
            _lService = service;
        }
    }
}
