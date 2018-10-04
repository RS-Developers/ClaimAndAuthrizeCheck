using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TeamTreeHouses_API.DataAccess.Entities
{
    public class GameEvent : EntityBase
    {
        public int PointValue { get; set; }

        public virtual Game Game { get; set; }
        public virtual Player Player { get; set; }
    }
}