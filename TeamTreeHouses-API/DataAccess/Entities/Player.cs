using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TeamTreeHouses_API.DataAccess.Entities
{
    public class Player : EntityBase
    {
        public string LastName { get; set; }
        public string FirstName { get; set; }

        public virtual Team Team { get; set; }
        public virtual ICollection<GameEvent> Events { get; set; }
    }
}