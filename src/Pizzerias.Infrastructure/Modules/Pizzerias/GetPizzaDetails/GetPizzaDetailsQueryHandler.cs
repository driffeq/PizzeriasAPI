using System.Threading;
using System.Threading.Tasks;
using Dapper;
using Pizzerias.Infrastructure.Configuration.Queries;
using Pizzerias.Infrastructure.Modules.Pizzerias.GetPizzas;
using Pizzerias.Persistance.Connection;

namespace Pizzerias.Infrastructure.Modules.Pizzerias.GetPizzaDetails
{
    public class GetPizzaDetailsQueryHandler : IQueryHandler<GetPizzaDetailQuery, PizzaDto>
    {
        private readonly ISqlConnectionFactory _connectionFactory;

        public GetPizzaDetailsQueryHandler(ISqlConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public async Task<PizzaDto> Handle(GetPizzaDetailQuery request, CancellationToken cancellationToken)
        {
            using var connection = _connectionFactory.GetOpenConnection();
            return await connection.QuerySingleAsync<PizzaDto>(
                "SELECT " +
                $"[Pizzas].[Name] AS [{nameof(PizzaDto.Name)}], " +
                $"[Pizzas].[Price] AS [{nameof(PizzaDto.Price)}], " +
                $"[Pizzas].[Ingredients] AS [{nameof(PizzaDto.Ingredients)}] " +
                "FROM [PizzeriasAPI].[dbo].[Pizzas] AS [Pizzas] " +
                "WHERE [Pizzas].[PizzeriaId] = @PizzeriaId and [Pizzas].[Id] = @PizzaId",
                new
                {
                    request.PizzeriaId, request.PizzaId
                });
        }
    }
}