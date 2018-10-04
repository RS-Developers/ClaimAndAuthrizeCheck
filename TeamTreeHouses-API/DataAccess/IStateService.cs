using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamTreeHouses_API.DataAccess.Entities;
using TeamTreeHouses_API.DataAccess.Repositories;

namespace TeamTreeHouses_API.DataAccess
{
    public interface IStateService
    {
        Repository<Team> Teams { get; }
        Repository<Game> Games { get; }
        Repository<Player> Players { get; }
        Repository<GameEvent> Events { get; }
    }
}
