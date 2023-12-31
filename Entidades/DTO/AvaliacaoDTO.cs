﻿using IAE.Entities.Enumarations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IAE.Entities.DTO
{
    public class AvaliacaoDTO
    {
        public TipoAvaliacao TipoAvaliacao { get; set; }
        public int IdTurma { get; set; }
        public int IdProfessor { get; set; }
        public List<int> IdsQuestoes { get; set; }
    }
}
