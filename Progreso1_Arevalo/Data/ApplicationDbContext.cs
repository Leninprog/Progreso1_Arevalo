using Microsoft.EntityFrameworkCore;
using Progreso1_ArevaloLenin.Models;

namespace Progreso1_Arevalo.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Reserva> Reservas { get; set; }
        public DbSet<PlanRecompensa> PlanRecompensas { get; set; }
    }
}