using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RoleTracker.Data;
using RoleTracker.DTO;
using RoleTracker.Models;

namespace RoleTracker.Services
{
    public class GameCrudService : IGameCrudService
    {
        private readonly RoleTrackerContext _context;

        public GameCrudService(RoleTrackerContext context)
        {
            _context = context;
        }

        public async Task CreateGameAsync(GameCommand gameCommand)
        {
            if (gameCommand is not null)
            {
                var newGame = new Game()
                {
                    Id = gameCommand.Id,
                    Name = gameCommand.Name,
                    MasterName = gameCommand.MasterName,
                    HoursPlayed = gameCommand.HoursPlayed,
                    StartedAt = gameCommand.StartedAt
                };

                _context.Game.Add(newGame);
                await _context.SaveChangesAsync();
            }
        }

        public async Task DeleteGameAsync(int id)
        {
            var game = await _context.Game.FirstOrDefaultAsync(c => c.Id == id);

            if (game is not null)
            {
                _context.Game.Remove(game);
                await _context.SaveChangesAsync();
            }
        }

        public async Task EditGameAsync(GameCommand gameCommand)
        {
            var game = await _context.Game.FirstOrDefaultAsync(c => c.Id == gameCommand.Id);

            if (game is not null)
            {
                game.Name = gameCommand.Name;
                game.MasterName = gameCommand.MasterName;
                game.HoursPlayed = gameCommand.HoursPlayed;
                game.StartedAt = gameCommand.StartedAt;

                _context.Attach(game).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }
        }
    }
}
