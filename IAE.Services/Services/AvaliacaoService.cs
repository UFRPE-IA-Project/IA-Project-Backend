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

        public void Insert(Avaliacao avaliacao)
        {
            _avaliacaoRepository.Insert(avaliacao);
        }

        public void Insert(IList<Avaliacao> avaliacoes)
        {
            _avaliacaoRepository.Insert(avaliacoes);
        }

        public Avaliacao GetById(int id)
        {
            return _avaliacaoRepository.GetById(id);
        }

        public IList<Avaliacao> GetAll()
        {
            return _avaliacaoRepository.GetAll();
        }

        public void Update(Avaliacao avaliacao)
        {
            _avaliacaoRepository.Update(avaliacao);
        }

        public void Delete(int id)
        {
            _avaliacaoRepository.Delete(id);
        }
    }
}