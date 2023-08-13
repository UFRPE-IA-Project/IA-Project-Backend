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


        // GET: Avaliacao/GetSimulado
        [HttpGet(Name = "Simulado")]
        [SwaggerOperation(Summary = "Obter um Simulado")]
        [SwaggerResponse(200)]
        [SwaggerResponse(400)]
        public Avaliacao GerarSimulado(Turma turma, Professor professor)
            
        {
            var avaliacao = _avaliacaoService.GerarSimulado(turma,professor);

            return avaliacao;
        }
        
        // GET: Avaliacao/GetProva
        [HttpGet(Name = "Prova")]
        [SwaggerOperation(Summary = "Obter uma Prova")]
        [SwaggerResponse(200)]
        [SwaggerResponse(400)]
        public Avaliacao GerarProva(Turma turma, Professor professor)

        {
            var avaliacao = _avaliacaoService.GerarProva(turma, professor);

            return avaliacao;
        }

    }
}
