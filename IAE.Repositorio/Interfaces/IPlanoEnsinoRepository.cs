using IAE.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IAE.Repository.Interfaces
{
    public interface IPlanoEnsinoRepository : IBaseRepository<PlanoEnsino>
    {
        int Insert(IList<PlanoEnsino> planosEnsino);

    }
}
