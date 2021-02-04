using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Pizzerias.Domain.Aggregates.PizzeriasAggregate;
using Pizzerias.Infrastructure.Configuration.Commands;

namespace Pizzerias.Infrastructure.Modules.Pizzerias.AddPizza
{
    public class AddPizzaCommandHandler: ICommandHandler<AddPizzaCommand>
    {
        private readonly IPizzeriaRepository _pizzeriaRepository;

        public AddPizzaCommandHandler(IPizzeriaRepository pizzeriaRepository)
        {
            _pizzeriaRepository = pizzeriaRepository;
        }

        public async Task<Unit> Handle(AddPizzaCommand request, CancellationToken cancellationToken)
        {
            var pizzeria = await _pizzeriaRepository.GetByIdAsync(new PizzeriaId(request.PizzeriaId));
            pizzeria.AddPizza(request.Name, request.Price, request.Ingredients);

            return Unit.Value;
        }
    }
}