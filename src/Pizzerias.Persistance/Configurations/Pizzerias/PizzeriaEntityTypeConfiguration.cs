using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pizzerias.Domain.Aggregates.PizzeriasAggregate;

namespace Pizzerias.Persistance.Configurations.Pizzerias
{
    public class PizzeriaEntityTypeConfiguration : IEntityTypeConfiguration<Pizzeria>
    {
        public void Configure(EntityTypeBuilder<Pizzeria> builder)
        {
            builder.ToTable("Pizzerias");

            builder.HasKey(x => x.Id);
            builder.Property<string>("_name").HasColumnName("Name").IsRequired();

            builder.OwnsMany<Pizza>("_pizzas", pizza =>
            {
                pizza.WithOwner().HasForeignKey("PizzeriaId");
                pizza.ToTable("Pizzas");
                pizza.HasKey("Id");
                pizza.Property<PizzaId>("Id");
                pizza.Property<PizzeriaId>("PizzeriaId");
                pizza.Property<string>("Name").HasColumnName("Name").IsRequired();
                pizza.Property<decimal>("_price").HasColumnName("Price").IsRequired();
                pizza.Property<string>("_ingredients").HasColumnName("Ingredients");
            });
        }
    }
}