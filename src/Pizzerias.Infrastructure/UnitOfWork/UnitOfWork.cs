using System.Threading;
using System.Threading.Tasks;
using Pizzerias.Domain.SharedKernel;
using Pizzerias.Persistance;

namespace Pizzerias.Infrastructure.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationContext _context;

        public UnitOfWork(ApplicationContext context)
        {
            _context = context;
        }
        public async Task<int> CommitAsync(CancellationToken cancellationToken = default)
        {
            await _context.Database.EnsureCreatedAsync(cancellationToken);
            return await _context.SaveChangesAsync(cancellationToken);
        }
    }
}