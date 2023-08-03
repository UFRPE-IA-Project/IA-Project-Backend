using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IAE.Entities.Entities
{
	public class Turma : BaseEntity
	{
		private static readonly Random _random = new Random();

		public Turma(Professor professor)
		{
			CodigoTurma = GerarCodigoTurma();
			Professor = professor ?? throw new ArgumentNullException(nameof(professor));
		}

		public string CodigoTurma { get; set; }
        public Professor Professor { get; set; }
        public List<Aluno> Alunos { get; set; } = new List<Aluno>();
        public PlanoEnsino PlanoEnsino { get; set; }


        private string GerarCodigoTurma()
		{
			var letrasNumeros = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
			var codigo = new StringBuilder();

			for (int i = 1; i <= 5; i++)
			{
				codigo.Append(letrasNumeros[_random.Next(letrasNumeros.Length)]);
			}

			return codigo.ToString();
		}
	}
}
