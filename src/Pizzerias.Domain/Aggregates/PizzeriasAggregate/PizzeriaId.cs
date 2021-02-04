
using System;
using Pizzerias.Domain.SharedKernel;

namespace Pizzerias.Domain.Aggregates.PizzeriasAggregate
{
    public class PizzeriaId : TypedIdValueBase
    {
        public PizzeriaId(Guid value) : base(value)
        {
        }
    }
}