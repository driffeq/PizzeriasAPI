using FluentValidation;

namespace Pizzerias.Infrastructure.Modules.Pizzerias.AddPizza
{
    public class AddPizzaCommandValidator : AbstractValidator<AddPizzaCommand>
    {
        public AddPizzaCommandValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Pizza name cannot be empty.");
            RuleFor(x => x.Price).GreaterThan(0).WithMessage("Pizza price has to be greater than 0.");
            RuleFor(x => x.PizzeriaId).NotNull().WithMessage("Pizza has to be attached to existing pizzeria.");
        }
    }
}