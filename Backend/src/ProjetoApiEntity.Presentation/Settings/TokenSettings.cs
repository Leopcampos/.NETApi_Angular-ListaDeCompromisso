using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ProjetoApiEntity.Presentation.Settings
{
    public class TokenSettings
    {
        //atributo
        private readonly JwtSettings jwtSettings;

        //construtor para inicializar o atributo (injeção de dependência)
        public TokenSettings(JwtSettings jwtSettings)
        {
            this.jwtSettings = jwtSettings;
        }

        public string GenerateToken(string userName)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.UTF8.GetBytes(jwtSettings.SecretKey);
            //montando o TOKEN
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                //usuario para o qual o TOKEN foi gerado
                Subject = new ClaimsIdentity(new Claim[] { new Claim(ClaimTypes.Name, userName) }),

                //data de expiração do TOKEN
                Expires = DateTime.Now.AddDays(1),

                //criptografia do TOKEN
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            //retornando o valor do TOKEN
            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }
    }
}