using IAE.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace IAE.Repository.Interfaces
{
	public interface IQuestaoRepository : IBaseRepository<Questao>
	{
        int Insert(IList<Questao> questoes);

    }
}
