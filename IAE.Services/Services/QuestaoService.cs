using IAE.Entidades.Entidades;
using IAE.Entities.Entities;
using IAE.Repository.Interfaces;
using IAE.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IAE.Services.Services
{

    public class QuestaoService : IQuestaoService
    {
        private readonly IQuestaoRepository _questaoRepository;
        private readonly Random _random = new Random();

        public QuestaoService(IQuestaoRepository questaoRepository)
        {
            _questaoRepository = questaoRepository;
        }

        public Questao ObterQuestao(int id)
        {
            var questao = _questaoRepository.FindById(id);
            ArgumentNullException.ThrowIfNull(questao);
            return questao;
        }

        public Questao AdicionarQuestao(Questao questao)
        {
            var questaoDb = _questaoRepository.Insert(questao);
			ArgumentNullException.ThrowIfNull(questaoDb);

            return questaoDb;
		}

		public Questao AtualizarQuestao(int id, Questao questao)
        {

            var questaoDb = ObterQuestao(id);
            ArgumentNullException.ThrowIfNull(questaoDb);

            questao.Id = questaoDb.Id;
            var questaoAtualizada = _questaoRepository.Update(questao);
			ArgumentNullException.ThrowIfNull(questaoAtualizada);

			return questaoAtualizada;
        }

        public void ApagarQuestao(int id)
        {
            var qtdDeletada = _questaoRepository.Delete(id);

            if (qtdDeletada < 1)
            {
                throw new Exception("Não foi possível apagar a questão");
            }

        }

        public IList<Questao> ObterQuestoes(){

            var questoes = _questaoRepository.FindAll();

            return questoes;
        }

		public List<Questao> ObterQuestoesPorQuantidade(int numeroQuestoes)
		{
            var todasQuestoes = ObterQuestoes();
			numeroQuestoes = Math.Min(numeroQuestoes, todasQuestoes.Count);

			var questoesRemanecentes = new List<Questao>(todasQuestoes);
            var questoesEscolhidas = new List<Questao>();

			for (int i = 0; i < numeroQuestoes; i++)
            {
                var indiceQuestao = _random.Next(todasQuestoes.Count);
				var questaoSelecionada = todasQuestoes[indiceQuestao];

                questoesEscolhidas.Add(questaoSelecionada);
				questoesRemanecentes.RemoveAt(indiceQuestao);
			}

            return questoesEscolhidas;
		}

        public bool VerificarAlternativaCorreta(int questaoId, int alternativaEscolhida)
        {
            Questao questao = _questaoRepository.FindById(questaoId);

            if (questao == null)
            {
                throw new Exception("Questão não encontrada");
            }

            return questao.AlternativaCorreta == alternativaEscolhida;
        }

        public List<Questao> ObterQuestaoPorPlanoEnsino(int idPlanoEnsino)
        {
            var questoes = _questaoRepository.FindAll();
            var questoesDoPlano = new List<Questao>();

            foreach (var questao in questoes)
            {
                if (questao.id_PlanoEnsino == idPlanoEnsino)
                {
                    questoesDoPlano.Add(questao);
                }
            }

            return questoesDoPlano;

        }


    }
}
