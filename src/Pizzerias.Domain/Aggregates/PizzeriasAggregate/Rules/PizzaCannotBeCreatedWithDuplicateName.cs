using System;
using System.Collections.Generic;
using System.Linq;
using Pizzerias.Domain.SharedKernel;

namespace Pizzerias.Domain.Aggregates.PizzeriasAggregate.Rules
{
    public class PizzaCannotBeCreatedWithDuplicateName : IBusinessRule
    {
        private readonly List<Pizza> _pizzas;
        private readonly string _name;
        public PizzaCannotBeCreatedWithDuplicateName(List<Pizza> pizzas, string name)
        {
            _pizzas = pizzas;
            _name = name;
        }

        public bool IsBroken() => _pizzas.Any(x => x.Name.Equals(_name, StringComparison.OrdinalIgnoreCase));

        public string Message => "Pizza with this name already exists.";
    }
}