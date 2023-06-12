using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace WebApiJwt.Models
{
    public class CreateToken
    {
        public string TokenCreate()
        {
            //Token oluşturmak için gerekli olan parametreler: 



            var bytes = Encoding.UTF8.GetBytes("aspnetcoreapiapi");
            SymmetricSecurityKey key = new SymmetricSecurityKey(bytes);
            //kimlik işlemi için:
            SigningCredentials credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            //key in yanındaki kısım jwt sitesindeki algorithm yazan kısımdır. kendisi default olarak HS256 verir.Ama sen HmacSha256 seçebilirsin. Yani bu şifreleme algoritmasıdır.

            //aşağıdaki ise jwt nin kendisini oluşturmaktır.
            JwtSecurityToken token = new JwtSecurityToken(issuer: "http://localhost", audience: "http://localhost", notBefore: DateTime.Now, expires: DateTime.Now.AddSeconds(20), signingCredentials: credentials);

            JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();
            return handler.WriteToken(token);
        }
        public string TokenCreateAdmin()
        {
            var bytes = Encoding.UTF8.GetBytes("aspnetcoreapiapi");
            SymmetricSecurityKey key = new SymmetricSecurityKey(bytes);
            SigningCredentials credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            //List claim hangi rollerin olacağını belirler
            List<Claim> claims = new List<Claim>()
            {
new Claim(ClaimTypes.NameIdentifier,Guid.NewGuid().ToString()),
new Claim(ClaimTypes.Role,"Admin"),
new Claim(ClaimTypes.Role,"Visitor")
            };
            JwtSecurityToken jwtSecurityToken = new JwtSecurityToken(issuer: "http://localhost", audience: "http://localhost", notBefore: DateTime.Now, expires: DateTime.Now.AddSeconds(30), signingCredentials: credentials, claims: claims);
            JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();
            return handler.WriteToken(jwtSecurityToken);
        }
    }
}
