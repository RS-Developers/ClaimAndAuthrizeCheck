using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TeamTreeHouses.Models.ViewModels
{
    public class TokenBlackListViewModel
    {
        public long Id { get; set; }
        public string Token { get; set; }
        public DateTime ExpireDateTime { get; set; }
    }
}