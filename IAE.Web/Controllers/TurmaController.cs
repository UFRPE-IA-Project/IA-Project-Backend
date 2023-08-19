using IAE.Entities.Entities;
using IAE.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace IAE.Web.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TurmaController : ControllerBase
    {
        private readonly ITurmaService _turmaService;

        public TurmaController(ITurmaService turmaService)
        {
            _turmaService = turmaService;
        }

        [HttpGet("{id}")]
        public ActionResult<Turma> GetTurma(int id)
        {
            var turma = _turmaService.BuscarTurmaPorId(id);
            if (turma == null)
            {
                return NotFound();
            }
            return Ok(turma);
        }

        [HttpGet("usuario/{usuarioId}")]
        public ActionResult<List<Turma>> GetTurmasPorUsuario(int usuarioId)
        {
            var usuario = new Usuario { Id = usuarioId };
            var turmas = _turmaService.BuscarTurmasPorUsuario(usuario);
            return Ok(turmas);
        }

        [HttpPost]
        public ActionResult<Turma> AdicionarTurma(Turma turma)
        {
			if (!ModelState.IsValid)
			{
				return BadRequest();
			}

			_turmaService.AdicionarTurma(turma);
            return Ok("Turma adicionada com sucesso.");
        }

        [HttpPut("{id}")]
        public ActionResult AtualizarTurma(int id, Turma turma)
        {
			if (!ModelState.IsValid)
			{
				return BadRequest();
			}
            			
            var turmaAtualizada = _turmaService.AtualizarTurma(id, turma);

            ArgumentNullException.ThrowIfNull(turmaAtualizada);

            return Ok("Turma atualizada com sucesso.");
        }

        [HttpDelete("{id}")]
        public ActionResult ExcluirTurma(int id)
        {
            var existingTurma = _turmaService.BuscarTurmaPorId(id);
            if (existingTurma == null)
            {
                return NotFound();
            }
            _turmaService.ExcluirTurma(id);
            return Ok("Turma excluída com sucesso.");
        }

        [HttpGet]
        public ActionResult<List<Turma>> ObterTodasTurmas()
        {
            var turmas = _turmaService.ObterTodasTurmas();
            return Ok(turmas);
        }
    }
}
