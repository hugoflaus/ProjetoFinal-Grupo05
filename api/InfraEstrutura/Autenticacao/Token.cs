using System;
using System.IdentityModel.Tokens.Jwt;
using System.IO;
using System.Security.Claims;
using System.Text;
using api.Dominio.Autenticação;
using api.Dominio.Entidade;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json.Linq;

namespace api.InfraEstrutura.Autenticação
{
    public class Token<T> : IToken
    {
        public string GerarToken(Usuario pessoa)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            JToken jAppSettings = JToken.Parse(File.ReadAllText(Path.Combine(Environment.CurrentDirectory, "appsettings.json")));
            var key = Encoding.ASCII.GetBytes(jAppSettings["JwtToken"].ToString());
            var expirationTime = Convert.ToInt32(jAppSettings["ExpirationTime"]);
            var tokenDescriptor = new SecurityTokenDescriptor()
            {
                Subject = new ClaimsIdentity(new Claim[]{
                        new Claim(ClaimTypes.Name, pessoa.Nome),
                        new Claim(ClaimTypes.Role, pessoa.Numero.ToString()),
                    }),
                Expires = DateTime.UtcNow.AddHours(expirationTime),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

         public string GerarToken(Operador pessoa)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            JToken jAppSettings = JToken.Parse(File.ReadAllText(Path.Combine(Environment.CurrentDirectory, "appsettings.json")));
            var key = Encoding.ASCII.GetBytes(jAppSettings["JwtToken"].ToString());
            var expirationTime = Convert.ToInt32(jAppSettings["ExpirationTime"]);
            var tokenDescriptor = new SecurityTokenDescriptor()
            {
                Subject = new ClaimsIdentity(new Claim[]{
                        new Claim(ClaimTypes.Name, pessoa.Nome),
                        new Claim(ClaimTypes.Role, pessoa.Numero.ToString()),
                    }),
                Expires = DateTime.UtcNow.AddHours(expirationTime),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}