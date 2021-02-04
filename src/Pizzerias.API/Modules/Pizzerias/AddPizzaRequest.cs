using System;
using System.Collections.Generic;

namespace Pizzerias.API.Modules.Pizzerias
{
    public class AddPizzaRequest
    {
        public Guid PizzeriaId { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public List<string> Ingredients { get; set; }
    }
}