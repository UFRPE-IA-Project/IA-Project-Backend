using IAE.Entities.Entities;
using IAE.Entities.DTO;
using IAE.Repository.Interfaces;
using IAE.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IAE.Services.Services
{
	public class UsuarioService : IUsuarioService
	{
		private readonly IUsuarioRepository _usuarioRepository;

        public UsuarioService(IUsuarioRepository usuarioRepository)
        {
			_usuarioRepository = usuarioRepository;

		}

        public Usuario AtualizarUsuario(int idUsuario, Usuario usuarioAtualizadoDto)
		{
			var usuario = GetUsuario(idUsuario);
			ArgumentNullException.ThrowIfNull(usuario);

			usuario.Id = usuarioAtualizadoDto.Id;

			var usuarioBD = _usuarioRepository.Update(usuario);

			return usuarioBD;
		}

		public void ExcluirUsuario(int idUsuario)
		{
			var linhasExcluidas = _usuarioRepository.Delete(idUsuario);

			if (linhasExcluidas < 1)
			{
				throw new ArgumentException("O usuário em questão não existe no banco de dados.");
			}
		}

		public Usuario GetUsuario(int id)
		{
			var usuario = _usuarioRepository.FindById(id);

			ArgumentNullException.ThrowIfNull(usuario);

			return usuario;
		}

		public List<Usuario> GetUsuarios(List<int> ids)
		{
			var usuarios = _usuarioRepository.FindByIds(ids).ToList();

			ArgumentNullException.ThrowIfNull(usuarios);

			return usuarios;
		}

		public List<Usuario> ObterTodosUsuarios()
		{
			var usuarios = _usuarioRepository.FindAll();

			return usuarios.ToList();
		}

		public Usuario AdicionarUsuario(UsuarioDTO usuarioDto)
		{
			var novoUsuario = CriarNovoUsuarioPeloDto(usuarioDto);
			var usuarioDb = _usuarioRepository.Insert(novoUsuario);

			ArgumentNullException.ThrowIfNull(usuarioDb);

			return usuarioDb;
		}

		private Usuario CriarNovoUsuarioPeloDto(UsuarioDTO dto)
		{
			var novoUsuario = new Usuario()
			{
				Nome = dto.Nome,
				Sobrenome = dto.Sobrenome,
				Email = dto.Email,
				Telefone = dto.Telefone,
				TipoUsuario = dto.TipoUsuario
			};

			return novoUsuario;
		}
	}
}
