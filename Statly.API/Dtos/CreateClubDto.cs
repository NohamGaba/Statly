namespace Statly.API.Dtos
{
    // DTO = objet que l'API reçoit depuis le client (Swagger, app mobile, etc.)
    public class CreateClubDto
    {
        // Nom du club (ex: "Olympique de Marseille")
        public string Name { get; set; } = null!;

        // Pays du club (ex: "France")
        public string Country { get; set; } = null!;

        // URL du logo du club
        public string LogoUrl { get; set; } = null!;
    }
}
