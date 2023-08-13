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
            avaliacao.TipoAvaliacao = TipoAvaliacao.simulado;
            
            
            
            return avaliacao;
        }
        public Avaliacao GerarProva(int turmaId)
        {

            Avaliacao avaliacao = new Avaliacao();
            avaliacao.TipoAvaliacao = TipoAvaliacao.prova;
           


            return avaliacao;
        }
    }
}
