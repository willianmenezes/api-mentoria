using Agendamento.Models;
using Microsoft.EntityFrameworkCore;

namespace Agendamento.Data
{
    public class AgendamentoContexto : DbContext
    {
        public DbSet<Reserva> Reservas { get; set; }
        public DbSet<Sala> Salas { get; set; }

        public AgendamentoContexto(DbContextOptions<AgendamentoContexto> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .LogTo(x => Console.WriteLine(x))
                .EnableSensitiveDataLogging();

            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AgendamentoContexto).Assembly);
        }
    }
}
