namespace IAE.Entidades.Entities
{
	public class ReferenciaBibliografica : BaseEntity
	{
        public string Referencia { get; set; }
        public List<PlanoEnsino> PlanosEnsino { get; set; } = new List<PlanoEnsino>();

    }
}