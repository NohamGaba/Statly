namespace Statly.API.Dtos.Football
{
    // DTO = ce que TON API renvoie au frontend
    public class LeagueDto
    {
        // Identifiant de la ligue (API Football)
        public int Id { get; set; }

        // Nom de la ligue (ex: Ligue 1)
        public string Name { get; set; } = null!;

        // Type (League / Cup)
        public string Type { get; set; } = null!;

        // Logo de la ligue
        public string Logo { get; set; } = null!;

        // Pays de la ligue
        public string Country { get; set; } = null!;
    }
}
