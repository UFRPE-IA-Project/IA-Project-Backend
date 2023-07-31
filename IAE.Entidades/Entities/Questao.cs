using IAE.Entities.Entities;

namespace IAE.Entidades.Entidades
{
    public class Questao : BaseEntity
    {
        public Questao()
        {
            Enunciado = string.Empty;
            Respostas = new List<Resposta>();
        }

        public string Enunciado { get; set; }
        public List<Resposta> Respostas { get; set; }
    }
}