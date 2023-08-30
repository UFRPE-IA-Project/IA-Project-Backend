using IAE.Entities.Entities;
using IAE.Entities.DTO;
using IAE.Entities.Enumarations;
using IAE.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IAE.Services.Services
{
    public class AvaliacaoService : IAvaliacaoService
    {
        private readonly IAvaliacaoRepository _avaliacaoRepository;
        private readonly ITurmaService _turmaService;
        private readonly IQuestaoService _questaoService;

        public AvaliacaoService(
            IAvaliacaoRepository avaliacaoRepository,
            ITurmaService turmaService,
            IQuestaoService questaoService)
        {
            _avaliacaoRepository = avaliacaoRepository;
            _turmaService = turmaService;
            _questaoService = questaoService;
        }

        public Avaliacao GetAvaliacao(int id)
        {
            var avaliacao = _avaliacaoRepository.FindById(id);
            ArgumentNullException.ThrowIfNull(avaliacao);

            return avaliacao;
        }

        public List<Avaliacao> ObterTodasAvaliacoes()
        {
            var avaliacoes = _avaliacaoRepository.FindAll();

            return avaliacoes.ToList();
        }
        public void ExcluirAvaliacao(int idAvaliacao)
        {
            _avaliacaoRepository.Delete(idAvaliacao);
        }

        public Avaliacao AtualizarAvaliacao(int idAvaliacao, AvaliacaoDTO avaliacaoAtualizadaDto)
        {
            var avaliacao = _avaliacaoRepository.FindById(idAvaliacao);
            ArgumentNullException.ThrowIfNull(avaliacao);

            avaliacao.TipoAvaliacao = avaliacaoAtualizadaDto.TipoAvaliacao;
            avaliacao.IdTurma = avaliacaoAtualizadaDto.IdTurma;
            avaliacao.IdProfessor = avaliacaoAtualizadaDto.IdProfessor;
            avaliacao.IdsQuestoes = avaliacaoAtualizadaDto.IdsQuestoes;

            var avaliacaoAtualizada = _avaliacaoRepository.Update(avaliacao);

            return avaliacaoAtualizada;
        }


        public Avaliacao GerarAvaliacao(int turmaId, int numeroQuestoes, TipoAvaliacao tipoAvaliacao)
        {

            Turma turma = _turmaService.BuscarTurmaPorId(turmaId);
            IList<Questao> questoes = _questaoService.ObterQuestaoPorPlanoEnsino(turma.IdPlanoEnsino);
            List<int> idsQuestoes = questoes.Select(q => q.Id!.Value).ToList();

            Avaliacao avaliacao = new Avaliacao();
            avaliacao.TipoAvaliacao = tipoAvaliacao;
            avaliacao.AlunosParticipantes = turma.Alunos;
            avaliacao.IdProfessor = turma.IdProfessor;
            avaliacao.IdsQuestoes = idsQuestoes;

            _avaliacaoRepository.Insert(avaliacao);

            return avaliacao;
		}

		public List<Avaliacao> GetAvaliacoesPorIdTurma(int idTurma)
		{
            var avaliacoes = _avaliacaoRepository.GetAvaliacoesPorIdTurma(idTurma);
            ArgumentNullException.ThrowIfNull(avaliacoes);

            return avaliacoes;
		}

		public List<Avaliacao> GetAvaliacoesPorIdProfessor(int idProfessor)
		{
			var avaliacoes = _avaliacaoRepository.GetAvaliacoesPorIdProfessor(idProfessor);
			ArgumentNullException.ThrowIfNull(avaliacoes);

			return avaliacoes;
		}

		private List<Questao> ObterQuestoes(int numeroQuestoes)
		{
            //TODO: implementar filtro de questões por disciplina/turma/tema
			var questoes = _questaoService.ObterQuestoesPorQuantidade(numeroQuestoes);
            return questoes;
		}
	}
}
