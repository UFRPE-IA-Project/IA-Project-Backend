using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IAE.Entidades.Entities
{
	public class PlanoEnsino : BaseEntity
	{
        public string? Nome { get; set; }
        public string NomeDisciplina { get; set; }
        public string Escolaridade { get; set; }
        public double CargaHoraria { get; set; }
        public List<ReferenciaBibliografica> ReferenciasBibliograficas { get; set; } = new List<ReferenciaBibliografica>();
        public List<string> TopicosAbordados { get; set; } = new List<string>();
    }
}
