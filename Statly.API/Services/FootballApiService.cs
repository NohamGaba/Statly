using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace Statly.API.Services;

public class FootballApiService
{
    // HttpClient sert à faire des requêtes HTTP (GET, POST, etc.)
    private readonly HttpClient _httpClient;

    // IConfiguration sert à lire appsettings.json / user-secrets
    private readonly IConfiguration _configuration;

    // Constructeur → appelé automatiquement par l'injection de dépendances
    public FootballApiService(HttpClient httpClient, IConfiguration configuration)
    {
        _httpClient = httpClient;
        _configuration = configuration;
    }

    // Méthode simple pour tester l'API Football
    public async Task<string> GetLeaguesRawAsync()
    {
        // On récupère la clé API depuis user-secrets
        var apiKey = _configuration["FootballApi:ApiKey"];

        // On ajoute le header obligatoire demandé par l'API
        _httpClient.DefaultRequestHeaders.Clear();
        _httpClient.DefaultRequestHeaders.Add("x-apisports-key", apiKey);

        // Appel GET vers https://v3.football.api-sports.io/leagues
        var response = await _httpClient.GetAsync("leagues");

        // On s'assure que la réponse est OK (200)
        response.EnsureSuccessStatusCode();

        // On lit le contenu JSON brut
        var content = await response.Content.ReadAsStringAsync();

        // On retourne le JSON tel quel (temporaire)
        return content;
    }
}
