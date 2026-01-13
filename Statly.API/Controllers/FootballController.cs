using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Statly.API.Services;

namespace Statly.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FootballController : ControllerBase
    {
        private readonly FootballApiService _footballApiService;

        // Le service est injecté automatiquement
        public FootballController(FootballApiService footballApiService)
        {
            _footballApiService = footballApiService;
        }

        // Endpoint de test
        [HttpGet("leagues")]
        public async Task<IActionResult> GetLeagues()
        {
            // Appel du service
            var result = await _footballApiService.GetLeaguesRawAsync();

            // On retourne le JSON brut pour test
            return Ok(result);
        }
    }
}
