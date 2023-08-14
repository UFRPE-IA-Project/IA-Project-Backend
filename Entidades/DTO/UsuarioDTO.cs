using IAE.Entities.Enumarations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IAE.Entities.DTO
{
	public class UsuarioDTO
	{
		public string Nome { get; set; }
		public string Sobrenome { get; set; }
		public string Telefone { get; set; } = string.Empty;
		public TipoUsuario TipoUsuario { get; set; }

		[EmailAddress]
		public string Email { get; set; }
	}
}
