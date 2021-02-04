using System.Threading.Tasks;
using Pizzerias.Domain.Aggregates.PizzeriasAggregate;
using Pizzerias.Persistance;

namespace Pizzerias.Infrastructure.Repositories.Pizzerias
{
    public class PizzeriaRepository : IPizzeriaRepository
    {
        private readonly ApplicationContext _context;

        public PizzeriaRepository(ApplicationContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Pizzeria pizzeria)
        {
            await _context.Pizzerias.AddAsync(pizzeria);
        }

        public async Task<Pizzeria> GetByIdAsync(PizzeriaId id)
        {
            return await _context.Pizzerias.FindAsync(id);
        }
    }
}