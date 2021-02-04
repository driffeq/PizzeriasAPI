using FluentValidation;

namespace Pizzerias.Infrastructure.Modules.Pizzerias.AddPizzeria
{
    public class AddPizzeriaCommandValidator : AbstractValidator<AddPizzeriaCommand>
    {
        public AddPizzeriaCommandValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Pizzeria name cannot be empty");
        }
    }
}