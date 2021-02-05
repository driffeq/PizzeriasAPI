using System;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Pizzerias.Infrastructure.Modules.Pizzerias.AddPizza;
using Pizzerias.Infrastructure.Modules.Pizzerias.AddPizzeria;
using Pizzerias.Infrastructure.Modules.Pizzerias.GetPizzaDetails;
using Pizzerias.Infrastructure.Modules.Pizzerias.GetPizzas;

namespace Pizzerias.API.Modules.Pizzerias
{
    [Route("api/[controller]")]
    [ApiController]
    public class PizzeriaController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PizzeriaController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("CreatePizzeria")]
        public async Task<IActionResult> CreatePizzeria(CreatePizzeriaRequest request)
        {
            var pizzeriaId = await _mediator.Send(new AddPizzeriaCommand(request.Name));
            return Ok(pizzeriaId);
        }

        [HttpPost("AddPizza")]
        public async Task<IActionResult> AddPizza(AddPizzaRequest request)
        {
            await _mediator.Send(new AddPizzaCommand(request.PizzeriaId, request.Name, request.Price, request.Ingredients));
            return Ok();
        }

        [HttpGet("{pizzeriaId}/GetPizzas")]
        public async Task<IActionResult> GetPizzas(Guid pizzeriaId)
        {
            var pizzas = await _mediator.Send(new GetPizzasQuery(pizzeriaId));
            return Ok(pizzas);
        }

        [HttpGet("{pizzeriaId}/GetPizza/{pizzaId}")]
        public async Task<IActionResult> GetPizzaDetails(Guid pizzeriaId, Guid pizzaId)
        {
            var pizzas = await _mediator.Send(new GetPizzaDetailQuery(pizzeriaId, pizzaId));
            return Ok(pizzas);
        }
    }
}
