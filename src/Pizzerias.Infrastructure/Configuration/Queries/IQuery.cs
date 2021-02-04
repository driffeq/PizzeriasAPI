using MediatR;

namespace Pizzerias.Infrastructure.Configuration.Queries
{
    public interface IQuery<out TResult> : IRequest<TResult>
    {
    }
}