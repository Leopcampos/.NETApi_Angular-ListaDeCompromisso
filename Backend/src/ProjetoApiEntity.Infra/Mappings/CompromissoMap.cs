using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjetoApiEntity.Domain.Entities;

namespace ProjetoApiEntity.Infra.Mappings
{
    public class CompromissoMap : IEntityTypeConfiguration<Compromisso>
    {
        public void Configure(EntityTypeBuilder<Compromisso> builder)
        {
            //chave primária
            builder.HasKey(c => c.IdCompromisso);

            //campos da tabela
            builder.Property(c => c.Nome)
            .HasMaxLength(150)
            .IsRequired();

            builder.Property(c => c.Data)
            .HasColumnType("date")
            .IsRequired();

            builder.Property(c => c.Hora)
            .HasColumnType("time")
            .IsRequired();

            builder.Property(c => c.Descricao)
            .HasMaxLength(500)
            .IsRequired();

            #region Mapeamento de Relacionamentos

            builder.HasOne(c => c.Usuario) //Compromisso TEM 1 Usuário
                .WithMany(u => u.Compromissos) //Usuário TEM MUITOS Compromissos
                .HasForeignKey(c => c.IdUsuario); //Chave estrangeira

            #endregion
        }
    }
}