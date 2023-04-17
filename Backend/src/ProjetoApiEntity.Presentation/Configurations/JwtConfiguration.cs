using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using ProjetoApiEntity.Presentation.Settings;
using System.Text;

namespace ProjetoApiEntity.Presentation.Configurations
{
    public static class JwtConfiguration
    {
        public static void AddJwt(this WebApplicationBuilder builder)
        {
            #region Lendo a configuração da palavra-secreta (appsettings.json)

            var settings = builder.Configuration.GetSection("JwtSettings");
            builder.Services.Configure<JwtSettings>(settings);

            var jwtSettings = settings.Get<JwtSettings>();
            var secretKey = Encoding.UTF8.GetBytes(jwtSettings.SecretKey);

            #endregion

            #region Configurando o framework JWT no projeto

            builder.Services.AddAuthentication(
                auth =>
                {
                    auth.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    auth.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                }
                ).AddJwtBearer(
                    bearer =>
                    {
                        bearer.RequireHttpsMetadata = false;
                        bearer.SaveToken = true;
                        bearer.TokenValidationParameters = new TokenValidationParameters
                        {
                            ValidateIssuerSigningKey = true,
                            IssuerSigningKey = new SymmetricSecurityKey(secretKey),
                            ValidateIssuer = false,
                            ValidateAudience = false
                        };
                    }
                );

            builder.Services.AddTransient(map => new TokenSettings(jwtSettings));

            #endregion
        }
    }
}