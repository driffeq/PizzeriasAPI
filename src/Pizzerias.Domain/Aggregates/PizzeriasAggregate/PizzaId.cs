using System;
using Pizzerias.Domain.SharedKernel;

namespace Pizzerias.Domain.Aggregates.PizzeriasAggregate
{
    public class PizzaId : TypedIdValueBase
    {
        public PizzaId(Guid value) : base(value)
        {
        }
    }
}