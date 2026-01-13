using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Statly.API.Dtos;
using Statly.Domain.Entities;
using Statly.Infrastructure.Data;

namespace Statly.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClubsController : ControllerBase
    {
        private readonly StatlyDbContext _context;

        public ClubsController(StatlyDbContext context)
        {
            _context = context;
        }

        // Sert à récupérer tous les clubs
        [HttpGet]
        public async Task<IActionResult> GetClubs()
        {
            // On récupère tous les clubs depuis la base
            var clubs = await _context.Clubs.ToListAsync();

            // On renvoie HTTP 200 + la liste
            return Ok(clubs);
        }

        // Sert à créer un club
        [HttpPost]
        public async Task<IActionResult> CreateClub(CreateClubDto dto)
        {
            // On transforme le DTO (données reçues)
            // en entité Club (base de données)
            var club = new Club
            {
                Name = dto.Name,
                Country = dto.Country,
                LogoUrl = dto.LogoUrl
            };

            // On ajoute le club au contexte EF
            _context.Clubs.Add(club);

            // On sauvegarde dans la base
            await _context.SaveChangesAsync();

            // On retourne HTTP 201 Created
            return CreatedAtAction(nameof(GetClubs), club);
        }
    }
}
