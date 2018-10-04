using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TeamTreeHouses_API.DataAccess.Entities;

namespace TeamTreeHouses_API.DataAccess.Repositories
{
    public class PlayerRepository : Repository<Player>
    {
        public PlayerRepository(StatesDbContext context): base(context)
        {
        }
    }
}