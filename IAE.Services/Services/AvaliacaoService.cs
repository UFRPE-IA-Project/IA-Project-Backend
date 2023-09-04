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

            var questoes = _questaoService.BuscarQuestoesPorAvaliacao(avaliacao.Id!.Value);

            avaliacao.Questoes = questoes;
            avaliacao.IdsQuestoes = questoes.Select(q =>q.Id!.Value).ToList();

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
            var questoes = _questaoService.ObterQuestaoPorPlanoEnsino(turma.IdPlanoEnsino);

            var questoesSelecionadas = ObterQuestoesAleatorias(numeroQuestoes, questoes);

            var idsQuestoes = questoesSelecionadas.Select(q => q.Id!.Value).ToList();

            var avaliacao = new Avaliacao
            {
                TipoAvaliacao = tipoAvaliacao,
                AlunosParticipantes = turma.Alunos,
                IdProfessor = turma.IdProfessor,
                IdsQuestoes = idsQuestoes,
                IdTurma = turmaId,
                Questoes = questoesSelecionadas
            };

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

		private List<Questao> ObterQuestoesAleatorias(int numeroQuestoes, List<Questao> questoesPlano)
		{
            //TODO: implementar filtro de questões por disciplina/turma/tema
			var questoes = _questaoService.ObterQuestoesAleatoriasPorQuantidade(numeroQuestoes, questoesPlano);
            return questoes;
		}
	}
}
