using System;
using System.Collections.Generic;
using Pizzerias.Domain.SharedKernel;

namespace Pizzerias.Domain.Aggregates.PizzeriasAggregate
{
    public class Pizza : Entity
    {
        internal PizzaId Id { get; private set; }
        internal PizzeriaId PizzeriaId { get; private set; }
        internal string Name;
        private decimal _price;
        private string _ingredients;
        public IReadOnlyCollection<string> Ingredients => _ingredients.Split(",");

        private Pizza() { }
        private Pizza(PizzeriaId pizzeriaId, string name, decimal price, List<string> ingredients)
        {
            Id = new PizzaId(Guid.NewGuid());
            PizzeriaId = pizzeriaId;
            Name = name;
            _price = price;
            _ingredients = string.Join(",", ingredients);
        }

        internal static Pizza CreateNew(PizzeriaId pizzeriaId, string name, decimal price, List<string> ingredients)
        {
            return new Pizza(pizzeriaId, name, price, ingredients);
        }

        internal void EditIngredient(string ingredients)
        {
            _ingredients = ingredients;
        }
    }
}