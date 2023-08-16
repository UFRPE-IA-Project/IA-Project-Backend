using IAE.Entidades.Entidades;
using IAE.Entities.Entities;
using IAE.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch.Operations;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Net;
using System.Collections.Generic;

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

        [HttpPost]
        [SwaggerOperation(Summary = "Obter um Simulado")]
        [SwaggerResponse(200)]
        [SwaggerResponse(400)]
        public Avaliacao GerarSimulado(int turmaId)
        {
            var avaliacao = _avaliacaoService.GerarSimulado(turmaId);
            return avaliacao;
        }

        [HttpPost]
        [SwaggerOperation(Summary = "Obter uma Prova")]
        [SwaggerResponse(200)]
        [SwaggerResponse(400)]
        public Avaliacao GerarProva(int turmaId)
        {
            var avaliacao = _avaliacaoService.GerarProva(turmaId);
            return avaliacao;
        }

        [HttpGet]
        public List<Avaliacao> BuscarAvaliacoes()
        {
            var avaliacoes = _avaliacaoService.BuscarAvaliacoes();
            return avaliacoes;
        }

        [HttpPost]
        public Avaliacao InserirAvaliacao(Avaliacao avaliacao)
        {
            var resultado = _avaliacaoService.InserirAvaliacao(avaliacao);
            return resultado;
        }

        [HttpPut]
        public Avaliacao AtualizarAvaliacao(Avaliacao avaliacao)
        {
            var resultado = _avaliacaoService.AtualizarAvaliacao(avaliacao);
            return resultado;
        }

        [HttpDelete]
        public int ExcluirAvaliacao(int id)
        {
            var resultado = _avaliacaoService.ExcluirAvaliacao(id);
            return resultado;
        }
    }
}