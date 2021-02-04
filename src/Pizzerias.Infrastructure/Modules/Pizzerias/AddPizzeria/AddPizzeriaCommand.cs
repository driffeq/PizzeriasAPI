using System;
using Pizzerias.Infrastructure.Configuration.Commands;

namespace Pizzerias.Infrastructure.Modules.Pizzerias.AddPizzeria
{
    public class AddPizzeriaCommand : CommandBase<Guid>
    {
        public string Name { get; set; }

        public AddPizzeriaCommand(string name)
        {
            Name = name;
        }
    }
}