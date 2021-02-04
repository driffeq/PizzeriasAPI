using System.Threading;
using System.Threading.Tasks;

namespace Pizzerias.Domain.SharedKernel
{
    public interface IUnitOfWork
    {
        Task<int> CommitAsync(CancellationToken cancellationToken = default);
    }
}