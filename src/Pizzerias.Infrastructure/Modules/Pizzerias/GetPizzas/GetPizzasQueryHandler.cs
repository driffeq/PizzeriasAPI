using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Dapper;
using Pizzerias.Infrastructure.Configuration.Queries;
using Pizzerias.Persistance.Connection;

namespace Pizzerias.Infrastructure.Modules.Pizzerias.GetPizzas
{
    public class GetPizzasQueryHandler : IQueryHandler<GetPizzasQuery, IEnumerable<PizzaDto>>
    {
        private readonly ISqlConnectionFactory _connectionFactory;

        public GetPizzasQueryHandler(ISqlConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public async Task<IEnumerable<PizzaDto>> Handle(GetPizzasQuery query, CancellationToken cancellationToken)
        {
            using var connection = _connectionFactory.GetOpenConnection();
            return await connection.QueryAsync<PizzaDto>(
                "SELECT " +
                $"[Pizzas].[Name] AS [{nameof(PizzaDto.Name)}], " +
                $"[Pizzas].[Price] AS [{nameof(PizzaDto.Price)}] " +
                "FROM [PizzeriasAPI].[dbo].[Pizzas] AS [Pizzas] " +
                "WHERE [Pizzas].[PizzeriaId] = @PizzeriaId",
                new
                {
                    query.PizzeriaId
                });
        }
    }
}