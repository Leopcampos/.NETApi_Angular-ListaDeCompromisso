using Microsoft.EntityFrameworkCore;
using ProjetoApiEntity.Domain.Entities;
using ProjetoApiEntity.Infra.Mappings;

namespace ProjetoApiEntity.Infra.Contexts
{
    //REGRA 1) Herdar DbContext
    public class SqlServerContext : DbContext
    {
        //REGRA 2) Construtor para receber como parametro as configurações
        //necessárias para a DbContext possa conectar-se a um banco de dados
        public SqlServerContext(DbContextOptions<SqlServerContext> options)
            : base (options) //construtor da superclasse
        {}

        //REGRA 3) Declarar uma propriedade DbSet para cada entidade mapeada
        //DbSet -> disponibilizar todos os métodos
        //de persistencia de dados (CRUD)
        //para cada entidade que foi mapeada.
        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<Compromisso> Compromisso { get; set; }


        //REGRA 4) Sobrescrever o método OnModelCreating
        //Utizado para indexar cada classe de mapeamento do projeto
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UsuarioMap());
            modelBuilder.ApplyConfiguration(new CompromissoMap());

            #region Criação de Índices no banco de dados

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasIndex(u => u.Email).IsUnique();
            });

            #endregion
        }
    }
}