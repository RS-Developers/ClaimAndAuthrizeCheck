using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TeamTreeHouses_API.DataAccess.Entities;

namespace TeamTreeHouses_API.DataAccess.Repositories
{
    public class GameEventRepository : Repository<GameEvent>
    {
        public GameEventRepository(StatesDbContext context) : base(context)
        {
        }
    }
}