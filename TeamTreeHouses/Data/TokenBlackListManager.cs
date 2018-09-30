using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ServiceStack.Redis;
using TeamTreeHouses.Interfaces;
using TeamTreeHouses.Models.ViewModels;

namespace TeamTreeHouses.Data
{
    public class TokenBlackListManager : ITokenBlackListManager
    {
        private readonly RedisClient _connection = new RedisClient();

        public void SaveIntoBlackList(string token, DateTime expireDatetime)
        {
            var tokenSave = _connection.As<TokenBlackListViewModel>();
            var last = tokenSave.GetAll().OrderBy(o => o.Id).LastOrDefault();
            long id = last == null ? 1 : last.Id++;

            tokenSave.Store(new TokenBlackListViewModel
            {
                Id = id,
                Token = token,
                ExpireDateTime = expireDatetime
            });
        }

        public bool CheckIsInBlackList(string token)
        {
            var tokenSave = _connection.As<TokenBlackListViewModel>();
            var invalids = tokenSave.GetAll().FirstOrDefault(w => w.Token == token);
            return invalids != null;
        }
    }
}