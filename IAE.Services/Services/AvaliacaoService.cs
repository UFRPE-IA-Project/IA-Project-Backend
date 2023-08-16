using IAE.Entidades.Entidades;
using IAE.Entities.DTO;
using IAE.Entities.Entities;
using IAE.Entities.Enumarations;
using IAE.Repository.Interfaces;
using IAE.Repository.Repositories;
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

            avaliacao.TipoAvaliacao = avaliacaoAtualizadaDto.TipoAvaliacao;
            avaliacao.IdTurma = avaliacaoAtualizadaDto.IdTurma;
            avaliacao.IdProfessor = avaliacaoAtualizadaDto.IdProfessor;
            avaliacao.IdsQuestoes = avaliacaoAtualizadaDto.IdsQuestoes;

            var avaliacaoAtualizada = _avaliacaoRepository.Update(avaliacao);

            return avaliacaoAtualizada;
        }


        public Avaliacao GerarSimulado(int turmaId)
        {

            Turma turma = _turmaService.BuscarTurmaPorId(turmaId);
            IList<Questao> questoes = _questaoService.ObterQuestoes();
            List<int> idsQuestoes = questoes.Select(q => q.Id ?? 0).ToList();


            Avaliacao avaliacao = new Avaliacao();
            avaliacao.TipoAvaliacao = TipoAvaliacao.Prova;
            avaliacao.AlunosParticipantes = turma.Alunos;
            avaliacao.IdProfessor = turma.IdProfessor;
            avaliacao.IdsQuestoes = idsQuestoes;

            _avaliacaoRepository.Insert(avaliacao);

            return avaliacao;
        }
        public Avaliacao GerarProva(int turmaId)
        {
            Turma turma = _turmaService.BuscarTurmaPorId(turmaId);
            IList <Questao> questoes = _questaoService.ObterQuestoes();
            List<int> idsQuestoes = questoes.Select(q => q.Id ?? 0).ToList();


            Avaliacao avaliacao = new Avaliacao();
            avaliacao.TipoAvaliacao = TipoAvaliacao.Prova;
            avaliacao.AlunosParticipantes = turma.Alunos;
            avaliacao.IdProfessor = turma.IdProfessor;
            avaliacao.IdsQuestoes = idsQuestoes;

            _avaliacaoRepository.Insert(avaliacao);

            return avaliacao;
        }
    }
}
