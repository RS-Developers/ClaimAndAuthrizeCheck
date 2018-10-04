using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TeamTreeHouses_API.DataAccess.Entities;

namespace TeamTreeHouses_API.DataAccess.Repositories
{
    public class TeamRepository : Repository<Team>
    {
        public TeamRepository(StatesDbContext context) : base(context)
        {
        }
    }
}