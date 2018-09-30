using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net.Http;
using System.Security.Claims;
using System.Web.Http;
using TeamTreeHouses.Data;
using TeamTreeHouses.Interfaces;
using TeamTreeHouses.Models.ViewModels;
using TeamTreeHouses.Tools;

namespace TeamTreeHouses.Controllers
{
    public class TokenController : BaseApiController
    {
        private readonly ITokenBlackListManager _tokenBlackListManager;

        public TokenController()
        {
            _tokenBlackListManager = new TokenBlackListManager();
        }

        [HttpPost]
        [AllowAnonymous]
        public IHttpActionResult SignIn([FromBody] LoginViewModel login)
        {
            LoginViewModel loginrequest = new LoginViewModel { };
            loginrequest.UserName = login.UserName.ToLower();
            loginrequest.Password = login.Password;

            bool isUsernamePasswordValid = false;

            if (login != null)
                isUsernamePasswordValid = loginrequest.Password == "admin" ? true : false;
            // if credentials are valid
            if (isUsernamePasswordValid)
            {
                string token = createToken("ItIsUserId");
                //return the token
                return Ok<string>(token);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPost]
        [JwtAuthorize]
        public IHttpActionResult SignOut()
        {
            var auth = System.Web.HttpContext.Current.Request.Headers.GetValues("Authorization");

            if (auth != null)
            {
                string jwtToken = auth.First().Substring(7);
                var tokenDecoded = new JwtSecurityToken(jwtEncodedString: jwtToken);
                var exp = Convert.ToInt64(tokenDecoded.Claims.First(c => c.Type == "exp").Value);
                var expDatetime = new DateTime(1970, 1, 1, 0, 0, 0).AddSeconds(exp);
                _tokenBlackListManager.SaveIntoBlackList(jwtToken, expDatetime);

                return Ok();
            }

            return NotFound();
        }

        [JwtAuthorize]
        public IHttpActionResult GetValue()
        {
            return Ok(UserId);
        }
        private string createToken(string userName)
        {
            DateTime issuedAt = DateTime.UtcNow;
            //set the time when it expires
            DateTime expires = DateTime.UtcNow.AddDays(7);

            //http://stackoverflow.com/questions/18223868/how-to-encrypt-jwt-security-token
            var tokenHandler = new JwtSecurityTokenHandler();

            //create a identity and add claims to the user which we want to log in
            ClaimsIdentity claimsIdentity = new ClaimsIdentity(new[]
            {
                new Claim(ClaimTypes.Name, userName)
            });

            const string sec = "401b09eab3c013d4ca54922bb802bec8fd5318192b0a75f201d8b3727429090fb337591abd3e44453b954555b7a0812e1081c39b740293f765eae731f5a65ed1";
            var now = DateTime.UtcNow;
            var securityKey = new Microsoft.IdentityModel.Tokens.SymmetricSecurityKey(System.Text.Encoding.Default.GetBytes(sec));
            var signingCredentials = new Microsoft.IdentityModel.Tokens.SigningCredentials(securityKey, Microsoft.IdentityModel.Tokens.SecurityAlgorithms.HmacSha256Signature);


            //create the jwt
            var token =
                (JwtSecurityToken)
                    tokenHandler.CreateJwtSecurityToken(issuer: "http://localhost:50191", audience: "http://localhost:50191",
                        subject: claimsIdentity, notBefore: issuedAt, expires: expires, signingCredentials: signingCredentials);
            var tokenString = tokenHandler.WriteToken(token);

            return tokenString;
        }
    }
}
