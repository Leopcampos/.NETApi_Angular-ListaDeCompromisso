using Microsoft.EntityFrameworkCore;
using ProjetoApiEntittyFramework.Infra.Contexts;
using ProjetoApiEntittyFramework.Infra.Contracts;
using ProjetoApiEntittyFramework.Infra.Repositories;

namespace ProjetoApiEntityFramework.Presentation.Configurations
{
    public static class EntityFrameworkConfiguration
    {
        public static void AddEntityFrameworkConfiguration(this WebApplicationBuilder builder)
        {
            #region Configuração do Contexto do EntityFramework

            builder.Services.AddDbContext<SqlServerContext>(options =>
                           options.UseSqlServer(builder.Configuration.GetConnectionString("Context")));

            #endregion

            #region Configuração das interfaces e classes de repositório

            builder.Services.AddTransient<IUsuarioRepository, UsuarioRepository>();
            builder.Services.AddTransient<ICompromissoRepository, CompromissoRepository>();

            #endregion
        }
    }
}