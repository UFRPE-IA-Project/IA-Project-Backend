using IAE.Entities.Enumarations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IAE.Entities.Entities
{
	public class Professor : Usuario
	{
		public Professor(string nome, string sobrenome, string email) : 
			base(nome, sobrenome, email)
		{
			TipoUsuario = TipoUsuario.Professor;
		}

        public List<Turma> Turmas { get; set; } = new List<Turma>();
        public List<PlanoEnsino> PlanosEnsino { get; set; } = new List<PlanoEnsino>();
        public List<Aluno> Alunos { get; set; } = new List<Aluno>();
	}
}
