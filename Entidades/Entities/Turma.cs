using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IAE.Entidades.Entities
{
	public class Turma : BaseEntity
	{
		private static readonly Random _random = new Random();

		public string CodigoTurma { get; set; } = GerarCodigoTurma();
        public int IdProfessor { get; set; }
        public int IdPlanoEnsino { get; set; }
        public Usuario Professor { get; set; }
        public List<Usuario> Alunos { get; set; } = new List<Usuario>();
        public PlanoEnsino PlanoEnsino { get; set; }


        private static string GerarCodigoTurma()
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
