using IAE.Entities.Enumarations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IAE.Entities.Entities
{
	public class Nota : BaseEntity
	{
        public Avaliacao Prova { get; set; }
        public double ValorNota { get; set; }
        public Usuario Aluno { get; set; }
        public TipoAvaliacao TipoAvaliacao { get; set; }
        public Turma Turma { get; set; }

    }
}
