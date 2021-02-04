using System;
using System.Collections.Generic;
using Pizzerias.Infrastructure.Configuration.Queries;

namespace Pizzerias.Infrastructure.Modules.Pizzerias.GetPizzas
{
    public class GetPizzasQuery : IQuery<IEnumerable<PizzaDto>>
    {
        public Guid PizzeriaId { get; set; }

        public GetPizzasQuery(Guid pizzeriaId)
        {
            PizzeriaId = pizzeriaId;
        }
    }
}