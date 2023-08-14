using IAE.Entidades.Entidades;
using IAE.Entities.Enumarations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IAE.Entities.Entities
{
	public class Avaliacao : BaseEntity
	{
        public Avaliacao()
        {
            Questoes = new List<Questao>();
        }

        public TipoAvaliacao TipoAvaliacao { get; set; }
        public Turma Turma { get; set; }
        public Usuario Professor { get; set; }
        public List<Questao> Questoes { get; set; }
        public List<Usuario> AlunosParticipantes { get; set; }
    }
}
