namespace Statly.API.Dtos
{
    // DTO de sortie = ce que l'API RENVOIE au client
    public class ClubDto
    {
        // Identifiant du club (côté API)
        public int Id { get; set; }

        // Nom du club
        public string Name { get; set; } = null!;

        // Pays du club
        public string Country { get; set; } = null!;

        // Logo du club
        public string LogoUrl { get; set; } = null!;
    }
}
