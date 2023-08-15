using IAE.Entidades.Entidades;
using IAE.Entities.Entities;
using IAE.Entities.Enumarations;
using IAE.Repository.Interfaces;
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
        public AvaliacaoService(IAvaliacaoRepository avaliacaoRepository)
        {
            _avaliacaoRepository = avaliacaoRepository;
        }
        public Avaliacao GerarSimulado(int turmaId)
        {
            
            Avaliacao avaliacao = new Avaliacao();
            avaliacao.TipoAvaliacao = TipoAvaliacao.Simulado;
            
            
            
            return avaliacao;
        }
        public Avaliacao GerarProva(int turmaId)
        {
            Turma turma = _turmaService.BuscarTurmaPorId(turmaId);
            IList <Questao> questoes = _questaoService.ObterQuestoes();
            List<int> idsQuestoes = questoes.Select(q => q.Id).ToList();

            Avaliacao avaliacao = new Avaliacao();
            avaliacao.TipoAvaliacao = TipoAvaliacao.Prova;
            avaliacao.AlunosParticipantes = turma.Alunos;
            avaliacao.IdProfessor = turma.IdProfessor;
            avaliacao.IdsQuestoes = idsQuestoes;


            return avaliacao;
        }
    }
}
