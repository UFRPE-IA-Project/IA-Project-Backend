using IAE.Entities.Entities;

namespace IAE.Entidades.Entidades
{
    public class Questao : BaseEntity
    {
        public string Enunciado { get; set; } = string.Empty;
        public string Alt1 { get; set; } = string.Empty;
        public string Alt2 { get; set; } = string.Empty;
        public string Alt3 { get; set; } = string.Empty;
        public string Alt4 { get; set; } = string.Empty;
        public int AlternativaCorreta { get; set; }
    }
}