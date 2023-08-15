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
        public ActionResult<Avaliacao> CreateAvaliacao(Avaliacao avaliacao)
        {
            _avaliacaoService.Insert(avaliacao);
            return CreatedAtAction(nameof(GetAvaliacaoById), new { id = avaliacao.Id }, avaliacao);
        }

        [HttpGet("{id}")]
        public ActionResult<Avaliacao> GetAvaliacaoById(int id)
        {
            var avaliacao = _avaliacaoService.GetById(id);
            if (avaliacao == null)
            {
                return NotFound();
            }
            return avaliacao;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Avaliacao>> GetAllAvaliacoes()
        {
            return _avaliacaoService.GetAll();
        }

        [HttpPut("{id}")]
        public IActionResult UpdateAvaliacao(int id, Avaliacao avaliacao)
        {
            if (id != avaliacao.Id)
            {
                return BadRequest();
            }

            _avaliacaoService.Update(avaliacao);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteAvaliacao(int id)
        {
            _avaliacaoService.Delete(id);
            return NoContent();
        }
    }
}