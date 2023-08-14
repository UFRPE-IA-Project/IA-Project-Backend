using IAE.Entidades.Entidades;
using IAE.Entities.Entities;
using IAE.Repository.Interfaces;
using IAE.Services.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IAE.Repository.Repositories
{
    public class AvaliacaoRepository : BaseRepository<Avaliacao>, IAvaliacaoRepository
    {
    }
}
