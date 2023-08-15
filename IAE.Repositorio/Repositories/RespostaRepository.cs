using IAE.Entidades.Entidades;
using IAE.Repositorio.Interfaces;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IAE.Repositorio.Repositories
{
	public class RespostaRepository : BaseRepository<Resposta>, IRespostaRepository
	{
		public RespostaRepository(IConfiguration config) : base(config)
		{
		}

		public override Resposta Insert(Resposta item)
		{
			throw new NotImplementedException();
		}

		public override int Insert(IList<Resposta> items)
		{
			throw new NotImplementedException();
		}

		public override Resposta Update(Resposta item)
		{
			throw new NotImplementedException();
		}
	}
}
