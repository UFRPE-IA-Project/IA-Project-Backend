using IAE.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IAE.Entities.DTO
{
	public class PlanoEnsinoDTO
	{
        public int? Id { get; set; }
        public string Nome { get; set; } = string.Empty;
		public string NomeDisciplina { get; set; } = string.Empty;
		public string Escolaridade { get; set; } = string.Empty;
		public double CargaHoraria { get; set; }
		public List<ReferenciaBibliografica>? ReferenciasBibliograficas { get; set; }
		public List<string>? TopicosAbordados { get; set; }
	}
}
