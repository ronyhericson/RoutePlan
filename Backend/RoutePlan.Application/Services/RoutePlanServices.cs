using System.Collections.Generic;
using System.Threading.Tasks;
using RoutePlan.Application.Services.Interfaces;
using RoutePlan.Domain.Entities;
using RoutePlan.Domain.Interfaces;

namespace RoutePlan.Application.Services
{
    public class RoutePlanServices : IRoutePlanServices
    {
        private readonly IRoutePlanRepository _routePlanRepository;

        public RoutePlanServices(IRoutePlanRepository routePlanRepository)
        {
            _routePlanRepository = routePlanRepository;
        }
        
        public async Task<int> Create(RoutePlanEntity routePlan)
        {
            return await _routePlanRepository.Create(routePlan);
        }

        public async Task<int> Update(RoutePlanEntity routePlan)
        {
            return await _routePlanRepository.Update(routePlan);
        }

        public async Task<long> Remove(int id)
        {
            return await _routePlanRepository.Remove(id);
        }

        public async Task<IEnumerable<RoutePlanEntity>> Get(int id = 0)
        {
            return await _routePlanRepository.Get(id);
        }
    }
}