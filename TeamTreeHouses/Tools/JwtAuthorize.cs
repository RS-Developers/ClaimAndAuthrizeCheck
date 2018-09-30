using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http.Controllers;
using TeamTreeHouses.Data;
using TeamTreeHouses.Interfaces;
using AuthorizeAttribute = System.Web.Http.AuthorizeAttribute;

namespace TeamTreeHouses.Tools
{
    public class JwtAuthorize : AuthorizeAttribute
    {
        private readonly ITokenBlackListManager _tokenBlackListManager;

        public JwtAuthorize()
        {
            _tokenBlackListManager = new TokenBlackListManager();
        }

        public override void OnAuthorization(HttpActionContext actionContext)
        {
            var auth = System.Web.HttpContext.Current.Request.Headers.GetValues("Authorization");

            if (auth != null)
            {
                string jwtToken = auth.First().Substring(7);
                var token = new JwtSecurityToken(jwtEncodedString: jwtToken);
                var exp = Convert.ToInt64(token.Claims.First(c => c.Type == "exp").Value);
                var exp_datetime = new DateTime(1970, 1, 1, 0, 0, 0).AddSeconds(exp);

                if (exp_datetime < DateTime.Now)
                {
                    HttpContext.Current.User = null;
                    actionContext.Response = new HttpResponseMessage(HttpStatusCode.Unauthorized);
                }
                else if(_tokenBlackListManager.CheckIsInBlackList(jwtToken))
                {
                    HttpContext.Current.User = null;
                }
            }
            base.OnAuthorization(actionContext);
        }
    }
}