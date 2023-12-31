﻿using IAE.Entities.DTO;
using IAE.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IAE.Services.Interfaces
{
	public interface IUsuarioService
	{
		Usuario GetUsuario(int id);
		List<Usuario> ObterTodosUsuarios();
		List<Usuario> GetUsuarios(List<int> ids);
		void ExcluirUsuario(int idUsuario);
		Usuario AtualizarUsuario(int idUsuario, Usuario usuarioAtualizado);
		Usuario AdicionarUsuario(UsuarioDTO usuario);
	}
}
