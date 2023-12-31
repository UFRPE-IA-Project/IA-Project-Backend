﻿using IAE.Entities.DTO;
using IAE.Entities.Entities;
using IAE.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace IAE.Web.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class UsuarioController : ControllerBase
	{
		private readonly IUsuarioService _usuarioService;

		public UsuarioController(IUsuarioService usuarioService)
		{
			_usuarioService = usuarioService;
		}

		[HttpGet("{id}")]
		public ActionResult<Usuario> GetUsuario(int id)
		{
			var usuario = _usuarioService.GetUsuario(id);

			ArgumentNullException.ThrowIfNull(usuario);

			return Ok(usuario);
		}

		[HttpGet]
		public ActionResult<List<Usuario>> ObterTodosUsuarios()
		{
			var usuarios = _usuarioService.ObterTodosUsuarios();

			ArgumentNullException.ThrowIfNull(usuarios);

			return Ok(usuarios);
		}

		[HttpPost("ObterPorIds")]
		public ActionResult<List<Usuario>> GetUsuarios(List<int> idsUsuarios)
		{
			var usuarios = _usuarioService.GetUsuarios(idsUsuarios);

			ArgumentNullException.ThrowIfNull(usuarios);

			return usuarios;
		}

		[HttpPut("{id}")]
		public ActionResult<Usuario> AtualizarUsuario(int id, Usuario usuarioAtualizado)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest();
			}

			var usuario = _usuarioService.AtualizarUsuario(id, usuarioAtualizado);

			ArgumentNullException.ThrowIfNull(usuario);

			return Ok(usuario);
		}

		[HttpPost]
		public ActionResult<Usuario> AdicionarUsuario(UsuarioDTO usuario)
		{
			var usuarioDb = _usuarioService.AdicionarUsuario(usuario);

			ArgumentNullException.ThrowIfNull(usuarioDb);

			return Ok(usuarioDb);
		}

		[HttpDelete("{id}")]
		public ActionResult ExcluirUsuario(int id)
		{
			var usuario = _usuarioService.GetUsuario(id);
			if (usuario is null)
			{
				return NotFound("Usuário não existe.");	
			}

			_usuarioService.ExcluirUsuario(id);

			return Ok("Usuario excluído com sucesso.");
		}
	}
}
