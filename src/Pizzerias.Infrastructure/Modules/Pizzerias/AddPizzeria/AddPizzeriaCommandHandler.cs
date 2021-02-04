using System;
using System.Threading;
using System.Threading.Tasks;
using Pizzerias.Domain.Aggregates.PizzeriasAggregate;
using Pizzerias.Infrastructure.Configuration.Commands;

namespace Pizzerias.Infrastructure.Modules.Pizzerias.AddPizzeria
{
    public class AddPizzeriaCommandHandler : ICommandHandler<AddPizzeriaCommand, Guid>
    {
        private readonly IPizzeriaRepository _pizzeriaRepository;

        public AddPizzeriaCommandHandler(IPizzeriaRepository pizzeriaRepository)
        {
            _pizzeriaRepository = pizzeriaRepository;
        }

        public async Task<Guid> Handle(AddPizzeriaCommand request, CancellationToken cancellationToken)
        {
            var pizzeria = Pizzeria.CreateNew(request.Name);
            await _pizzeriaRepository.AddAsync(pizzeria);
            return pizzeria.Id.Value;
        }
    }
}