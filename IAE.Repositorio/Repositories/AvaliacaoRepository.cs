using IAE.Entidades.Entidades;
using IAE.Entities.Entities;
using IAE.Repository.Interfaces;
using IAE.Services.Services;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IAE.Repository.Repositories
{
    public class AvaliacaoRepository : BaseRepository<Avaliacao>, IAvaliacaoRepository
    {
        public AvaliacaoRepository(IConfiguration config) :
            base(config)
        {
                
        }

		public override Avaliacao Insert(Avaliacao item)
		{
			throw new NotImplementedException();
		}

		public override int Insert(IList<Avaliacao> items)
		{
			throw new NotImplementedException();
		}

		public override Avaliacao Update(Avaliacao item)
		{
			throw new NotImplementedException();
		}
	}
}
