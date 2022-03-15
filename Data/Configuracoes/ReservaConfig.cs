using Agendamento.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Agendamento.Data.Configuracoes
{
    public class ReservaConfig : IEntityTypeConfiguration<Reserva>
    {
        public void Configure(EntityTypeBuilder<Reserva> builder)
        {
            builder.ToTable("Reservas");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Titulo)
                    .IsUnicode(false)
                    .HasMaxLength(200)
                    .IsRequired();

            builder.Property(x => x.Descricao)
                   .IsUnicode(false)
                   .HasMaxLength(2000)
                   .IsRequired();

            builder.Property(x => x.Inicio)
                   .IsRequired();

            builder.Property(x => x.Fim)
                   .IsRequired();

            builder.Property(x => x.SalaId)
                   .IsRequired();
        }
    }
}
