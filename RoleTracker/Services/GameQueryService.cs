using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RoleTracker.Data;
using RoleTracker.Models;

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

        public async Task<Game?> GetGameByIdAsync(int id)
        {
            Game? game = null;
            if (_context.Game is not null)
            {
                game = await _context.Game.FirstOrDefaultAsync(m => m.Id == id);
            }

            return game;
        }

        public async Task<List<Game>> GetGamesAsync()
        {
            var games = new List<Game>();
            if (_context.Game is not null)
            {
                games = await _context.Game.ToListAsync();
            }

            return games;
        }

        public async Task<bool> GameExistsAsync(int id)
        {
            if (_context.Game is null)
                return false;

            return await _context.Game.AnyAsync(c => c.Id == id);
        }
    }
}
