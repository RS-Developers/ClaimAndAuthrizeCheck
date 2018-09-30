using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TeamTreeHouses.Interfaces
{
    public interface ITokenBlackListManager
    {
        void SaveIntoBlackList(string token, DateTime expireDatetime);
        bool CheckIsInBlackList(string token);
    }
}