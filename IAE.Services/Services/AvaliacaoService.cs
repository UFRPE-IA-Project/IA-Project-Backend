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
            Avaliacao avaliacao = new Avaliacao();
            avaliacao.TipoAvaliacao = TipoAvaliacao.Prova;
            return avaliacao;
        }

        public List<Avaliacao> BuscarAvaliacoes()
        {
            return _avaliacaoRepository.FindAll();
        }

        public Avaliacao InserirAvaliacao(Avaliacao avaliacao)
        {
            return _avaliacaoRepository.Insert(avaliacao);
        }

        public int InserirAvaliacoes(List<Avaliacao> avaliacoes)
        {
            return _avaliacaoRepository.Insert(avaliacoes);
        }

        public Avaliacao AtualizarAvaliacao(Avaliacao avaliacao)
        {
            return _avaliacaoRepository.Update(avaliacao);
        }

        public int ExcluirAvaliacao(int id)
        {
            return _avaliacaoRepository.Delete(id);
        }
    }
}