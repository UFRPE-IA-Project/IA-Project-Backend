using IAE.Entities.Entities;
using IAE.Repository.Interfaces;
using IAE.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IAE.Services.Services
{
	public class OpenAiService : IOpenAiService
	{
		private readonly IOpenAiRepository _openAiRepository;

		public OpenAiService(IOpenAiRepository openAiRepository)
		{
			_openAiRepository = openAiRepository;
		}

		public void AddChave(string chave)
		{
			var novaChave = new ChaveOpenAI(chave);

			var chaveDb = _openAiRepository.Insert(novaChave);
			ArgumentNullException.ThrowIfNull(chaveDb);

			if (string.IsNullOrEmpty(chaveDb.Chave)
				|| !novaChave.Chave!.Equals(chave))
			{
				throw new Exception("Houve um erro ao adicionar a chave. A chave fornecida não é a mesma retornada pelo banco.");
			}
		}

		public void DeleteChave(int id)
		{
			_openAiRepository.Delete(id);
		}

		public string GetChave(int id)
		{
			var chaveDb = _openAiRepository.FindById(id);
			ArgumentNullException.ThrowIfNull(chaveDb);

			if (string.IsNullOrEmpty(chaveDb.Chave))
			{
				throw new ArgumentNullException(nameof(chaveDb.Chave));
			}

			return chaveDb.Chave;
		}

		public string GetLastChave()
		{
			var chave = _openAiRepository.GetLastChave();

			if (string.IsNullOrEmpty(chave))
			{
				throw new ArgumentException("Houve algum erro ao recuperar a ultima chave adicionada.");
			}

			return chave;
		}

		public void UpdateChave(int id, string chave)
		{
			if (string.IsNullOrEmpty(chave))
			{
				throw new ArgumentException("Chave fornecida é nula ou vazia.");
			}

			var chaveDb = _openAiRepository.FindById(id);
			ArgumentNullException.ThrowIfNull(chaveDb);

			chaveDb.Chave = chave;
			chaveDb.ModificadaEm = chaveDb.RegistarData();

			_openAiRepository.Update(chaveDb);
		}
	}
}
