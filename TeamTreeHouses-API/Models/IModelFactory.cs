using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamTreeHouses_API.DataAccess.Entities;

namespace TeamTreeHouses_API.Models
{
    public interface IModelFactory
    {
        Team Create(TeamModel model);
        TeamModel Create(Team entity);
        Player Create(PlayerModel model);
        PlayerModel Create(Player entity);
    }
}
