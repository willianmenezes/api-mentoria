using Agendamento.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Agendamento.Data.Configuracoes
{
    public class SalaConfig : IEntityTypeConfiguration<Sala>
    {
        public void Configure(EntityTypeBuilder<Sala> builder)
        {
            builder.ToTable("Salas");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Nome)
                    .IsUnicode(false)
                    .HasMaxLength(200)
                    .IsRequired();

            builder.Property(x => x.QuantidadeDeLugares)
                    .IsRequired();

            builder.Property(x => x.Andar)
                   .IsRequired();

            builder.Property(x => x.Status)
                 .IsRequired();

            builder.HasMany(x => x.Reservas)
                    .WithOne(x => x.Sala)
                    .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
