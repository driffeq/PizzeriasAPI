using System.Threading.Tasks;

namespace Pizzerias.Domain.Aggregates.PizzeriasAggregate
{
    public interface IPizzeriaRepository
    {
        Task AddAsync(Pizzeria pizzeria);

        Task<Pizzeria> GetByIdAsync(PizzeriaId id);
    }
}