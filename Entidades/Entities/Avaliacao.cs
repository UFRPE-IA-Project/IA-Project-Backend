using IAE.Entities.Entities;
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
        public TipoAvaliacao TipoAvaliacao { get; set; }
        public int IdTurma { get; set; }
        public int IdProfessor { get; set; }
        public List<int> IdsQuestoes { get; set; }
        public Turma Turma { get; set; }
        public Usuario Professor { get; set; }
        public List<Questao> Questoes { get; set; }
        public List<Usuario> AlunosParticipantes { get; set; }
    }
}
