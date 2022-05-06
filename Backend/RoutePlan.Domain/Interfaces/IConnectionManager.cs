using System.Data;
using System.Threading.Tasks;

namespace RoutePlan.Domain.Interfaces
{
    public interface IConnectionManager
    {
        Task<IDbConnection> GetConnectionAsync(string database = null);
    }
}