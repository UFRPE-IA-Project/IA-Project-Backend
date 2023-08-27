using IAE.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IAE.Services.Interfaces
{
	public interface IOpenAiService
	{
		string GetChave(int id);
		string GetLastChave();
		void AddChave(string chave);
		void UpdateChave(int id, string chave);
		void DeleteChave(int id);
	}
}
