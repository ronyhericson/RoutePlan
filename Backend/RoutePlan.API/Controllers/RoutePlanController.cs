using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RoutePlan.Application.Services.Interfaces;
using RoutePlan.Domain.Entities;
using RoutePlan.Domain.ViewModel;

namespace RoutePlan.API.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class RoutePlanController : ControllerBase
    {
        private readonly IRoutePlanServices _routePlanService;
        private readonly IMapper _mapper;

        public RoutePlanController(IRoutePlanServices routePlanService, IMapper mapper)
        {
            _routePlanService = routePlanService;
            _mapper = mapper;
        }
        
        [HttpPost]        
        [ProducesResponseType(typeof(RoutePlanViewModel), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<RoutePlanViewModel>> Create([FromBody] RoutePlanViewModel routePlan)
        {
            var viewModel = new RoutePlanViewModel();
            var domain = _mapper.Map<RoutePlanEntity>(viewModel);
            var retunCreated = await _routePlanService.Create(domain);

            if(retunCreated == 0)
                return BadRequest(new { message = "Problemas para inserir esta rota." });

            
            return Ok(new { message = "Rota inserida com sucesso." });
        }

        [HttpPut]        
        [ProducesResponseType(typeof(RoutePlanViewModel), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<RoutePlanViewModel>> Update([FromBody] RoutePlanViewModel routePlan)
        {
            var viewModel = new RoutePlanViewModel();
            var domain = _mapper.Map<RoutePlanEntity>(viewModel);
            var retunCreated = await _routePlanService.Update(domain);

            if(retunCreated == 0)
                return BadRequest(new { message = "Problemas para alterar esta rota." });

            
            return Ok(new { message = "Rota alterada com sucesso." });
        }

        [HttpDelete]   
        [Route("{id}")]     
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<string>> Remove(int id)
        {
            var removeMovto = await _routePlanService.Remove(id);

            if(removeMovto == 0)
                return BadRequest(new { message = "Problemas para remover esta rota." });

            return Ok(new { message = "Rota removida com sucesso." });
        }

        [HttpGet]          
        [ProducesResponseType(typeof(IEnumerable<RoutePlanViewModel>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<RoutePlanViewModel>>> Get()
        {
            var list = await _routePlanService.Get();

            var listViewModel = _mapper.Map<List<RoutePlanViewModel>>(list);

            return Ok(listViewModel);
        }
        
        [HttpGet]            
        [Route("{id}")]
        [ProducesResponseType(typeof(IEnumerable<RoutePlanViewModel>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<RoutePlanViewModel>>> GetLancamentoById(int id = 0)
        {
            var list = await _routePlanService.Get(id);

            var listViewModel = _mapper.Map<List<RoutePlanViewModel>>(list);

            return Ok(listViewModel);
        }
    }
}