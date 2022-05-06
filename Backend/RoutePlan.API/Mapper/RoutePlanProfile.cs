using AutoMapper;
using RoutePlan.Domain.Entities;
using RoutePlan.Domain.ViewModel;

namespace FluxoCaixa.API.Mapper
{
    public class RoutePlanProfile : Profile
    {
        public RoutePlanProfile()
        {
            CreateMap<RoutePlanViewModel, RoutePlanEntity>().ReverseMap();
        }
    }
}