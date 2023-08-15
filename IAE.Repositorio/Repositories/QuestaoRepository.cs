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
	public class QuestaoRepository : BaseRepository<Questao>, IQuestaoRepository
	{
		public QuestaoRepository(IConfiguration config) : base(config)
		{
		}

		public override Questao Insert(Questao item)
		{
			throw new NotImplementedException();
		}

		public override int Insert(IList<Questao> items)
		{
			throw new NotImplementedException();
		}

		public override Questao Update(Questao item)
		{
			throw new NotImplementedException();
		}
	}
}
