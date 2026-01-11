using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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

        [HttpGet]
        public async Task<IActionResult> GetClubs()
        {
            var clubs = await _context.Clubs.ToListAsync();
            return Ok(clubs);
        }
    }
}
