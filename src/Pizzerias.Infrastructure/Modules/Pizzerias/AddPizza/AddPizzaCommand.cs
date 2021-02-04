using System;
using System.Collections.Generic;
using Pizzerias.Infrastructure.Configuration.Commands;

namespace Pizzerias.Infrastructure.Modules.Pizzerias.AddPizza
{
    public class AddPizzaCommand : CommandBase
    {
        public Guid PizzeriaId { get; }
        public string Name { get; }
        public decimal Price { get; }
        public List<string> Ingredients { get; set; }

        public AddPizzaCommand(Guid pizzeriaId, string name, decimal price, List<string> ingredients)
        {
            PizzeriaId = pizzeriaId;
            Name = name;
            Price = price;
            Ingredients = ingredients;
        }
    }
}