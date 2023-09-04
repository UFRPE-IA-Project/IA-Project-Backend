using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IAE.Entities.DTO
{
    public class RespostaDTO
    {
        public RespostaDTO() { }
        public RespostaDTO(string resposta, bool isCorreta)
        {
            Resposta = resposta;
            IsCorreta = isCorreta;
        }

        public string Resposta { get; set; }
        public bool IsCorreta { get; set; }
    }
}
