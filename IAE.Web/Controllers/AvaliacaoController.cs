using IAE.Entidades.Entidades;
using IAE.Entities.Entities;
using IAE.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch.Operations;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Net;

namespace IAE.Web.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class AvaliacaoController : ControllerBase
    {
        private readonly IAvaliacaoService _avaliacaoService;

        public AvaliacaoController(IAvaliacaoService avaliacaoService)
        {
            _avaliacaoService = avaliacaoService;
        }


        // POST: Avaliacao/PostSimulado
        [HttpGet(Name = "Simulado")]
        [SwaggerOperation(Summary = "Obter um Simulado")]
        [SwaggerResponse(200)]
        [SwaggerResponse(400)]
        public Avaliacao GerarSimulado(int turmaId)
            
        {
            var avaliacao = _avaliacaoService.GerarSimulado(turmaId);

            return avaliacao;
        }
        
        // POST: Avaliacao/PostProva
        [HttpGet(Name = "Prova")]
        [SwaggerOperation(Summary = "Obter uma Prova")]
        [SwaggerResponse(200)]
        [SwaggerResponse(400)]
        public Avaliacao GerarProva(int turmaId)
        {
            var avaliacao = _avaliacaoService.GerarProva(turmaId);

            return avaliacao;
        }

    }
}
