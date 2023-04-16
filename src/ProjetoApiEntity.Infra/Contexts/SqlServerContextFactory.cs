using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace ProjetoApiEntity.Infra.Contexts
{
    public class SqlServerContextFactory : IDesignTimeDbContextFactory<SqlServerContext>
    {
        public SqlServerContext CreateDbContext(string[] args)
        {
            #region Ler a connectionString mapeada no appsettings.json

            var builder = new ConfigurationBuilder();
            var path = Path.Combine(Directory.GetCurrentDirectory(), "appsettings.json");
            builder.AddJsonFile(path);

            var root = builder.Build();
            var connectionString = root.GetSection("ConnectionStrings").GetSection("Context").Value;

            #endregion

            #region Configurando o Migrations

            var options = new DbContextOptionsBuilder<SqlServerContext>();
            options.UseSqlServer(connectionString);

            return new SqlServerContext(options.Options);

            #endregion
        }
    }
}