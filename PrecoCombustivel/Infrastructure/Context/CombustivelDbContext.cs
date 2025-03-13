using Microsoft.EntityFrameworkCore;
using PrecoCombustivel.Domain.Entities;

namespace PrecoCombustivel.Infrastructure.Context
{
    public class CombustivelDbContext : DbContext
    {
        public CombustivelDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Combustivel> Combustiveis { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Combustivel>().HasKey(x => x.Id);
            base.OnModelCreating(modelBuilder);
        }
    }
}
