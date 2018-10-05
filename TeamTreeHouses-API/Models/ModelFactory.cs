using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TeamTreeHouses_API.DataAccess.Entities;

namespace TeamTreeHouses_API.Models
{
    public class ModelFactory : IModelFactory
    {

        public Team Create(TeamModel model)
        {
            return new Team()
            {
                Id = model.TeamId,
                Name = model.TeamName,
                //
            };
        }

        public TeamModel Create(Team entity)
        {
            return new TeamModel()
            {
                TeamId = entity.Id,
                TeamName = entity.Name,
            };
        }

        public Player Create(PlayerModel model)
        {
            return new Player()
            {
                //Id = model.PlayerId,
                LastName = model.LastName,
                FirstName = model.FirstName,
                //
                CreateDate = DateTime.Now,
                UpdateDate = DateTime.Now,
            };
        }

        public PlayerModel Create(Player entity)
        {
            if (entity == null)
                return null;
            //
            return new PlayerModel()
            {
                PlayerId = entity.Id,
                LastName = entity.LastName,
                FirstName = entity.FirstName,
                //
                TeamId = entity.Team != null ? entity.Team.Id : 0,
                TeamName = entity.Team != null ? entity.Team.Name : string.Empty,
            };
        }
    }
}