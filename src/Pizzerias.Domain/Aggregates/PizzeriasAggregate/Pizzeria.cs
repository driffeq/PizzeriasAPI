using System;
using System.Collections.Generic;
using System.Linq;
using Pizzerias.Domain.Aggregates.PizzeriasAggregate.Rules;
using Pizzerias.Domain.SharedKernel;

namespace Pizzerias.Domain.Aggregates.PizzeriasAggregate
{
    public class Pizzeria : Entity, IAggregateRoot
    {
        public PizzeriaId Id { get; private set; }
        private string _name;
        private List<Pizza> _pizzas;

        private Pizzeria()
        {
            _pizzas = new List<Pizza>();
        }
        private Pizzeria(string name)
        {
            Id = new PizzeriaId(Guid.NewGuid());
            _name = name;
            _pizzas = new List<Pizza>();
        }

        public static Pizzeria CreateNew(string name)
        {
            return new Pizzeria(name);
        }

        public void AddPizza(string name, decimal price, List<string> ingredients)
        {
            CheckRule(new PizzaCannotBeCreatedWithDuplicateName(_pizzas, name));
            _pizzas.Add(Pizza.CreateNew(Id, name, price, ingredients));
        }

        public void EditPizzaIngredients(PizzaId pizzaId, string ingredients)
        {
            var pizza = GetPizza(pizzaId);
            pizza.EditIngredient(ingredients);
        }

        private Pizza GetPizza(PizzaId pizzaId)
        {
            return _pizzas.SingleOrDefault(x => x.Id.Equals(pizzaId));
        }
    }
}