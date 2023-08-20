using IAE.Entidades.Entidades;
using IAE.Entities.Entities;
using IAE.Entities.Enumarations;
using IAE.Services.Interfaces;
using IAE.Entities.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch.Operations;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Net;

namespace IAE.Web.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AvaliacaoController : ControllerBase
    {
        private readonly IAvaliacaoService _avaliacaoService;

        public AvaliacaoController(IAvaliacaoService avaliacaoService)
        {
            _avaliacaoService = avaliacaoService;
        }

        [HttpGet("{id}")]
		[SwaggerResponse(200)]
		[SwaggerResponse(400)]
		public ActionResult<Avaliacao> GetAvaliacao(int id)
        {
            var avaliacao = _avaliacaoService.GetAvaliacao(id);

            return Ok(avaliacao);
        }

		[HttpGet("Turma/{id}")]
		[SwaggerResponse(200)]
		[SwaggerResponse(400)]
		public ActionResult<Avaliacao> GetAvaliacoesPorIdTurma(int id)
		{
			List<Avaliacao> avaliacoes = _avaliacaoService.GetAvaliacoesPorIdTurma(id);

			return Ok(avaliacoes);
		}

		[HttpGet("Professor/{id}")]
		[SwaggerResponse(200)]
		[SwaggerResponse(400)]
		public ActionResult<Avaliacao> GetAvaliacoesPorIdProfessor(int id)
		{
			List<Avaliacao> avaliacoes = _avaliacaoService.GetAvaliacoesPorIdProfessor(id);

			return Ok(avaliacoes);
		}

		// POST: Avaliacao/PostSimulado
		[HttpPost("GerarSimulado")]
        [SwaggerOperation(Summary = "Obter um Simulado")]
        [SwaggerResponse(200)]
        [SwaggerResponse(400)]
        public ActionResult<Avaliacao> GerarSimulado(int turmaId, int numeroQuestoes)
            
        {
            var avaliacao = _avaliacaoService.GerarAvaliacao(turmaId, numeroQuestoes, TipoAvaliacao.Simulado);

            return Ok(avaliacao);
        }
        
        // POST: Avaliacao/PostProva
        [HttpPost("GerarProva")]
        [SwaggerOperation(Summary = "Obter uma Prova")]
        [SwaggerResponse(200)]
        [SwaggerResponse(400)]
        public ActionResult<Avaliacao> GerarProva(int turmaId, int numeroQuestoes)
        {
            var avaliacao = _avaliacaoService.GerarAvaliacao(turmaId, numeroQuestoes, TipoAvaliacao.Prova); ;

            return Ok(avaliacao);
        }

        // PUT: api/Avaliacao/AtualizarAvaliacao
        [HttpPut("AtualizarAvaliacao")]
        [SwaggerOperation(Summary = "Atualizar uma Avaliacao")]
        [SwaggerResponse(200)]
        [SwaggerResponse(400)]
        public ActionResult<Avaliacao> AtualizarAvaliacao(int idAvaliacao, AvaliacaoDTO avaliacaoAtualizada)
        {
            var avaliacaoAtualizadaRetorno = _avaliacaoService.AtualizarAvaliacao(idAvaliacao, avaliacaoAtualizada);
            return Ok(avaliacaoAtualizadaRetorno);
        }

        // DELETE: api/Avaliacao/ExcluirAvaliacao/{id}
        [HttpDelete("ExcluirAvaliacao/{id}")]
        [SwaggerOperation(Summary = "Excluir uma Avaliacao")]
        [SwaggerResponse(200)]
        [SwaggerResponse(400)]
        public ActionResult ExcluirAvaliacao(int id)
        {
            _avaliacaoService.ExcluirAvaliacao(id);
            return Ok();
        }

    }
}
