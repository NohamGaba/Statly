using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Statly.API.Dtos.Football;
using System.Linq;

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

    public async Task<List<LeagueDto>> GetLeaguesAsync()
    {
        var apiKey = _configuration["FootballApi:ApiKey"];

        _httpClient.DefaultRequestHeaders.Clear();
        _httpClient.DefaultRequestHeaders.Add("x-apisports-key", apiKey);

        var response = await _httpClient.GetAsync("leagues");
        response.EnsureSuccessStatusCode();

        var json = await response.Content.ReadAsStringAsync();

        // On parse le JSON
        using var doc = JsonDocument.Parse(json);

        var leagues = doc.RootElement
         .GetProperty("response")      // On récupère la propriété "response"
         .EnumerateArray()             // 🔥 On dit : "c'est un tableau"
         .Select(l => new LeagueDto    // Maintenant LINQ fonctionne
         {
             // Id de la ligue
             Id = l.GetProperty("league").GetProperty("id").GetInt32(),

             // Nom de la ligue
             Name = l.GetProperty("league").GetProperty("name").GetString()!,

             // Type (League / Cup)
             Type = l.GetProperty("league").GetProperty("type").GetString()!,

             // Logo
             Logo = l.GetProperty("league").GetProperty("logo").GetString()!,

             // Pays
             Country = l.GetProperty("country").GetProperty("name").GetString()!
         })
         .ToList(); // On transforme en List<LeagueDto>


        return leagues;
    }

}
