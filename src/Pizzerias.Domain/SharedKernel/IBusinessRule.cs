namespace Pizzerias.Domain.SharedKernel
{
    public interface IBusinessRule
    {
        bool IsBroken();
        string Message { get; }
    }
}