using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IAE.Entities.Entities
{
	public class PlanoEnsino : BaseEntity
	{
        public string Nome { get; set; } = string.Empty;
        public string NomeDisciplina { get; set; } = string.Empty;
		public string Escolaridade { get; set; } = string.Empty;
		public double CargaHoraria { get; set; }
        public List<ReferenciaBibliografica> ReferenciasBibliograficas { get; set; } = new List<ReferenciaBibliografica>();
        public List<string> TopicosAbordados { get; set; } = new List<string>();
    }
}
