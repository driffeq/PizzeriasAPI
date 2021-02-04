using Microsoft.EntityFrameworkCore;
using Pizzerias.Domain.Aggregates.PizzeriasAggregate;

namespace Pizzerias.Persistance
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Pizzeria> Pizzerias { get; set; }

        public ApplicationContext(DbContextOptions options) : base(options)
        {
        }
        

        protected override void OnModelCreating(ModelBuilder modelBuilder)
            => modelBuilder.ApplyConfigurationsFromAssembly(this.GetType().Assembly);
    }
}