using IAE.Entidades.Entidades;
using IAE.Entities.Entities;
using IAE.Services.Interfaces; // Você pode remover esta linha se a classe AvaliacaoService não estiver mais implementando a interface
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch.Operations;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Net;
using System.Collections.Generic;
using IAE.Services.Services;

namespace IAE.Web.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class AvaliacaoController : ControllerBase
    {
        private readonly AvaliacaoService _avaliacaoService; // Mudando de IAvaliacaoService para AvaliacaoService

        public AvaliacaoController(AvaliacaoService avaliacaoService) // Mudando de IAvaliacaoService para AvaliacaoService
        {
            _avaliacaoService = avaliacaoService;
        }

        // POST: Avaliacao/PostSimulado
        [HttpPost]
        [SwaggerOperation(Summary = "Obter um Simulado")]
        [SwaggerResponse(200)]
        [SwaggerResponse(400)]
        public Avaliacao GerarSimulado(int turmaId)
        {
            var avaliacao = _avaliacaoService.GerarSimulado(turmaId);
            return avaliacao;
        }

        // POST: Avaliacao/PostProva
        [HttpPost]
        [SwaggerOperation(Summary = "Obter uma Prova")]
        [SwaggerResponse(200)]
        [SwaggerResponse(400)]
        public Avaliacao GerarProva(int turmaId)
        {
            var avaliacao = _avaliacaoService.GerarProva(turmaId);
            return avaliacao;
        }

        [HttpPost]
        public ActionResult<Avaliacao> Create(Avaliacao avaliacao)
        {
            return Ok(_avaliacaoService.Create(avaliacao));
        }

        [HttpGet]
        public ActionResult<IEnumerable<Avaliacao>> ReadAll()
        {
            return Ok(_avaliacaoService.ReadAll());
        }

        [HttpGet]
        public ActionResult<Avaliacao> ReadById(int id)
        {
            return Ok(_avaliacaoService.ReadById(id));
        }

        [HttpPut]
        public ActionResult<Avaliacao> Update(Avaliacao avaliacao)
        {
            return Ok(_avaliacaoService.Update(avaliacao));
        }

        [HttpDelete]
        public ActionResult Delete(int id)
        {
            _avaliacaoService.Delete(id);
            return NoContent();
        }
    }
}