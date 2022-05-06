using System.Collections.Generic;
using System.Threading.Tasks;
using RoutePlan.Domain.Entities;

namespace RoutePlan.Domain.Interfaces
{
    public interface IRoutePlanRepository 
    {
        Task<int> Create(RoutePlanEntity routePlan);
        Task<int> Update(RoutePlanEntity routePlan);
        Task<long> Remove(int id);
        Task<IEnumerable<RoutePlanEntity>> Get(int id = 0);
        
    }
}