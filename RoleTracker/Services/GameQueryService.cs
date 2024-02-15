using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RoleTracker.Data;

namespace RoleTracker.Services
{
    public class GameQueryService : IGameQueryService
    {
        private readonly RoleTrackerContext _context;

        public GameQueryService(RoleTrackerContext context)
        {
            _context = context;
        }

        public async Task<List<SelectListItem>> GetGamesForSelector()
        {
            var games = await _context.Game.ToListAsync();
            return games.Select(g => new SelectListItem { Value = g.Id.ToString(), Text = g.Name }).ToList();
        }
    }
}
