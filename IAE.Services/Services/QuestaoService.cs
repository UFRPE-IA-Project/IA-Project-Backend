using IAE.Entities.DTO;
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

            //ManipularStringRecebidaSeparandoPropriedades(questao.Enunciado, questao);

            var questaoDb = _questaoRepository.Insert(questao);
			ArgumentNullException.ThrowIfNull(questaoDb);

            return questaoDb;
        }

        public List<Questao> AdicionarMultiplasQuestoes(List<Questao> questoes)
        {
            var listaErros = new List<string>();

            for(int indiceQuestao = 1; indiceQuestao >= questoes.Count; indiceQuestao++)
            {
                var enunciadoExiste = string.IsNullOrEmpty(questoes[indiceQuestao-1].Enunciado);

                if (!enunciadoExiste)
                {
                    listaErros.Add($"Questão {indiceQuestao} da lista não possui enunciado");
                }
            }

            _questaoRepository.Insert(questoes);

            return questoes;
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

		public List<Questao> ObterQuestoesAleatoriasPorQuantidade(int numeroQuestoes, List<Questao> questoes)
		{
			numeroQuestoes = Math.Min(numeroQuestoes, questoes.Count);

			var questoesRemanecentes = new List<Questao>(questoes);
            var questoesEscolhidas = new List<Questao>();

			for (int i = 0; i < numeroQuestoes; i++)
            {
                var indiceQuestao = _random.Next(questoesRemanecentes.Count);
				var questaoSelecionada = questoesRemanecentes[indiceQuestao];

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
            var questoes = _questaoRepository.FindAll()
                .Where(q => q.id_PlanoEnsino == idPlanoEnsino)
                .ToList();

            return questoes;
        }

        public List<Questao> EstruturarQuestoes(Questao questoes)
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

                RandomizarResposta(questao);

                listaQuestoes.Add(questao);
            }

            return listaQuestoes;
        }

        private void RandomizarResposta(Questao questao)
        {
            var listaRespostas = CriarListaRespostas(questao);
            RandomizarRespostas(listaRespostas);
            AtualizarQuestaoComRespostas(questao, listaRespostas);
        }

        private List<RespostaDTO> CriarListaRespostas(Questao questao)
        {
            var listaRespostas = new List<RespostaDTO>
            {
                new RespostaDTO(questao.Alt1, false),
                new RespostaDTO(questao.Alt2, false),
                new RespostaDTO(questao.Alt3, false),
                new RespostaDTO(questao.Alt4, false)
            };

            listaRespostas[questao.AlternativaCorreta - 1].IsCorreta = true;

            return listaRespostas;
        }

        private void RandomizarRespostas(List<RespostaDTO> listaRespostas)
        {
            int n = listaRespostas.Count;
            while (n > 1)
            {
                n--;
                int k = _random.Next(n + 1);
                var valor = listaRespostas[k];
                listaRespostas[k] = listaRespostas[n];
                listaRespostas[n] = valor;
            }
        }

        private void AtualizarQuestaoComRespostas(Questao questao, List<RespostaDTO> listaRespostas)
        {
            questao.Alt1 = listaRespostas[0].Resposta;
            questao.Alt2 = listaRespostas[1].Resposta;
            questao.Alt3 = listaRespostas[2].Resposta;
            questao.Alt4 = listaRespostas[3].Resposta;

            // Encontra a alternativa correta
            questao.AlternativaCorreta = listaRespostas.FindIndex(r => r.IsCorreta) + 1;
        }

        public List<Questao> BuscarQuestoesPorAvaliacao(int idAvaliacao)
        {
            var questoes = _questaoRepository.BuscarQuestoesPorAvaliacao(idAvaliacao);

            return questoes;
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
