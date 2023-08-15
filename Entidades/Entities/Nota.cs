using IAE.Entidades.Enumarations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IAE.Entidades.Entities
{
	public class Nota : BaseEntity
	{
        public int IdProva { get; set; }
        public double ValorNota { get; set; }
        public int IdAluno { get; set; }
        public TipoAvaliacao TipoAvaliacao { get; set; }
        public int IdProfessor { get; set; }
        public int IdTurma { get; set; }
        public Avaliacao Prova { get; set; }
        public Usuario Aluno { get; set; }
        public Turma Turma { get; set; }

    }
}
