using System;
using Pizzerias.Infrastructure.Configuration.Queries;
using Pizzerias.Infrastructure.Modules.Pizzerias.GetPizzas;

namespace Pizzerias.Infrastructure.Modules.Pizzerias.GetPizzaDetails
{
    public class GetPizzaDetailQuery : IQuery<PizzaDto>
    {
        public Guid PizzeriaId { get; set; }
        public Guid PizzaId { get; set; }

        public GetPizzaDetailQuery(Guid pizzeriaId, Guid pizzaId)
        {
            PizzeriaId = pizzeriaId;
            PizzaId = pizzaId;
        }
    }
}