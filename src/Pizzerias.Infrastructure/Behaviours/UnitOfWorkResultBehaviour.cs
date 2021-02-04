using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Pizzerias.Domain.SharedKernel;
using Pizzerias.Infrastructure.Configuration.Commands;

namespace Pizzerias.Infrastructure.Behaviours
{
    public class UnitOfWorkResultBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : ICommand<TResponse>
    {
        private readonly IUnitOfWork _unitOfWork;

        public UnitOfWorkResultBehaviour(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            var response = await next();
            await _unitOfWork.CommitAsync(cancellationToken);
            return response;
        }
    }
}