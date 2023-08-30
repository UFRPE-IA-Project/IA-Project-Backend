using IAE.Entities.Entities;
using IAE.Repository.Interfaces;
using IAE.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

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
            if (string.IsNullOrWhiteSpace(questao.Enunciado))
            {
                throw new ArgumentNullException("Questão parece estar vazia ou nula");
            }

            ManipularStringRecebidaSeparandoPropriedades(questao.Enunciado, questao);

            var questaoDb = _questaoRepository.Insert(questao);
			ArgumentNullException.ThrowIfNull(questaoDb);

            return questaoDb;
        }

        public void AdicionarMultiplasQuestoes(Questao questoes)
        {
            if (string.IsNullOrWhiteSpace(questoes.Enunciado))
            {
                throw new ArgumentNullException("Questão parece estar vazia ou nula");
            }

            var questoesString = questoes.Enunciado.Split("ENUNCIADO:", StringSplitOptions.RemoveEmptyEntries)
                             .Select(question => $"ENUNCIADO:{question.Trim()}")
                             .ToList();

            var listaQuestoes = new List<Questao>();

            if (questoesString is null || !(questoesString.Count > 0))
            {
                throw new ArgumentNullException("As questões enviadas são nulas ou não estão estruturadas corretamente");
            }

            foreach (var questaoString in questoesString)
            {
                var questao = new Questao();
                questao.Enunciado = questaoString;
                questao.AlternativaCorreta = 1;

                ManipularStringRecebidaSeparandoPropriedades(questao.Enunciado, questao);

                listaQuestoes.Add(questao);
            }

            var questoesDb = _questaoRepository.Insert(listaQuestoes);
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
            var questao = _questaoRepository.FindById(id);

            if (questao is null)
            {
                throw new ArgumentNullException("Não foi possível apagar a questão, ela não existe no banco de dados ou já foi deletada");
            }

             _questaoRepository.Delete(id);
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

        private void ManipularStringRecebidaSeparandoPropriedades(string stringRecebida, Questao questao)
        {
            stringRecebida = RemoverTextoInicial(stringRecebida);
            
            string[] linhas = stringRecebida.Split('\n', StringSplitOptions.RemoveEmptyEntries);
            questao.AlternativaCorreta = 1;

            for (int i = 0; i < linhas.Length; i++)
            {
                string linha = linhas[i].Trim();
                int indiceDoisPontos = linha.IndexOf(':');

                if (indiceDoisPontos != -1 && indiceDoisPontos != 0)
                {
                    string nomePropriedade = linha.Substring(0, indiceDoisPontos).Trim();
                    string valorPropriedade = linha.Substring(indiceDoisPontos + 1).Trim();

                    switch (nomePropriedade)
                    {
                        case "ENUNCIADO":
                            questao.Enunciado = valorPropriedade;
                            break;
                        case "RESPOSTA 1":
                            questao.Alt1 = valorPropriedade;
                            break;
                        case "RESPOSTA 2":
                            questao.Alt2 = valorPropriedade;
                            break;
                        case "RESPOSTA 3":
                            questao.Alt3 = valorPropriedade;
                            break;
                        case "RESPOSTA 4":
                            questao.Alt4 = valorPropriedade;
                            break;
                        default:
                            throw new ArgumentException($"A palavra '{nomePropriedade}' não faz parte da estrutura esperada de uma questão");
                    }
                }
                else
                {
                    throw new ArgumentException("O texto recebido não parece estar estruturado de maneira esperada.");
                }
            }
        }

        private string RemoverTextoInicial(string texto)
        {
            int enunciadoIndex = texto.IndexOf("ENUNCIADO:");

            if (enunciadoIndex != -1)
            {
                return texto.Substring(enunciadoIndex);
            }
            else
            {
                return texto;
            }
        }
    }
}
