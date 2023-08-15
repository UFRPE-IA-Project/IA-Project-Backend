using IAE.Entidades.Entidades;
using IAE.Repository.Interfaces;
using IAE.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IAE.Services.Services
{
    public class QuestaoService : IQuestaoService
    {
        private readonly IQuestaoRepository _questaoRepository;

        public QuestaoService(IQuestaoRepository questaoRepository)
        {
            _questaoRepository = questaoRepository;
        }

        public Questao ObterQuestao(int id)
        {
            var questao = _questaoRepository.FindById(id);
            return questao;
        }

        public void AdicionarQuestao(Questao questao)
        {
            var idQuestao = _questaoRepository.Add(questao);

            if (idQuestao != -1)
            {
                throw new Exception("Não foi possível adicionar a questão");
            }
        }

        public void ApagarQuestao(int id)
        {
            var qtdDeletada = _questaoRepository.Delete(id);

            if (qtdDeletada != -1)
            {
                throw new Exception("Não foi possível apagar a questão");
            }
        }

        public IEnumerable<Questao> ListarQuestoes()
        {
            var questoes = _questaoRepository.GetAll();
            return questoes;
        }

        public void AtualizarQuestao(Questao questao)
        {
            var questaoAtualizada = _questaoRepository.Update(questao);
            if (questaoAtualizada is null)
            {
                throw new Exception("Não foi possível atualizar a questão");
            }
        }
    }
}