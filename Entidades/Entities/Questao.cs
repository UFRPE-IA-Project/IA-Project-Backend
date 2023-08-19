using IAE.Entities.Entities;

namespace IAE.Entidades.Entidades
{
    public class Questao : BaseEntity
    {
        public string Enunciado { get; set; } = string.Empty;
        public List<Resposta>? Respostas { get; set; }
        public List<string>? Tags { get; set; }
    }
}