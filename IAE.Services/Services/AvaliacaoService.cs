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

        // Métodos CRUD

        public Avaliacao Create(Avaliacao avaliacao)
        {
            return _avaliacaoRepository.Insert(avaliacao);
        }

        public IEnumerable<Avaliacao> ReadAll()
        {
            return _avaliacaoRepository.FindAll();
        }

        public Avaliacao ReadById(int id)
        {
            return _avaliacaoRepository.FindById(id);
        }

        public Avaliacao Update(Avaliacao avaliacao)
        {
            return _avaliacaoRepository.Update(avaliacao);
        }

        public void Delete(int id)
        {
            _avaliacaoRepository.Delete(id);
        }
    }
}