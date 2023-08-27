using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IAE.Entities.Entities
{
	public class ChaveOpenAI : BaseEntity
	{
		public ChaveOpenAI() { }
        public ChaveOpenAI(string chave)
		{
			Chave = chave;
			CriadaEm = RegistarData();
		}

		public string? Chave { get; set; }
        public string? CriadaEm { get; set; }
        public string? ModificadaEm { get; set; }

		public string RegistarData()
		{
			return DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
		}
	}
}
