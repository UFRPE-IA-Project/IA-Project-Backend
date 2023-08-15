using IAE.Entidades.Entities;

namespace IAE.Entidades.Entidades
{
    public class Questao : BaseEntity
    {
        public string Enunciado { get; set; }
        public List<Resposta> Respostas { get; set; }
        public List<string> Tags { get; set; } = new List<string>();
    }
}