using IAE.Entidades.DTO;
using IAE.Entidades.Entities;
using IAE.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace IAE.Web.Controllers
{
	[ApiController]
	[Route("[controller]/[action]")]
	public class UsuarioController : ControllerBase
	{
		private readonly IUsuarioService _usuarioService;

		public UsuarioController(IUsuarioService usuarioService)
		{
			_usuarioService = usuarioService;
		}

		[HttpGet(Name = "Usuario")]
		public Usuario GetUsuario(int idUsuario)
		{
			var usuario = _usuarioService.GetUsuario(idUsuario);

			ArgumentNullException.ThrowIfNull(usuario);

			return usuario;
		}

		[HttpGet]
		public List<Usuario> ObterTodosUsuarios()
		{
			var usuarios = _usuarioService.ObterTodosUsuarios();

			ArgumentNullException.ThrowIfNull(usuarios);

			return usuarios;
		}

		[HttpGet]
		public List<Usuario> GetUsuarios(List<int>idsUsuarios)
		{
			var usuarios = _usuarioService.GetUsuarios(idsUsuarios);

			ArgumentNullException.ThrowIfNull(usuarios);

			return usuarios;
		}

		[HttpPost]
		public ActionResult AtualizarUsuario(int idUsuario, UsuarioDTO usuarioAtualizado)
		{
			var usuario = _usuarioService.AtualizarUsuario(idUsuario, usuarioAtualizado);

			ArgumentNullException.ThrowIfNull(usuario);

			return Ok(usuario);
		}

		[HttpPost]
		public ActionResult AdicionarUsuario(UsuarioDTO usuario)
		{
			var usuarioDb = _usuarioService.AdicionarUsuario(usuario);

			ArgumentNullException.ThrowIfNull(usuarioDb);

			return Ok(usuarioDb);
		}

		[HttpDelete]
		public ActionResult ExcluirUsuario(int idUsuario)
		{
			_usuarioService.ExcluirUsuario(idUsuario);

			return Content("Usuario excluído com sucesso.");
		}
	}
}
