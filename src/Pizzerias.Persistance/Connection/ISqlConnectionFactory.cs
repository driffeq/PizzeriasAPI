using System.Data;

namespace Pizzerias.Persistance.Connection
{
    public interface ISqlConnectionFactory
    {
        IDbConnection GetOpenConnection();
    }
}