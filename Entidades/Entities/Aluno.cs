using IAE.Entities.Enumarations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IAE.Entities.Entities
{
	public class Aluno : Usuario
	{
        public Aluno(string nome, string sobrenome, string email) :
			base(nome, sobrenome, email)
		{
			Turmas = new List<Turma>();
			Notas = new List<Nota>();
			TipoUsuario = TipoUsuario.Aluno;
		}

        public List<Turma> Turmas { get; set; }
        public List<Nota> Notas { get; set; }
    }
}
