using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RoleTracker.Data;
using RoleTracker.Models;

namespace RoleTracker.Services
{
    public class CharacterQueryService : ICharacterQueryService
    {
        private readonly RoleTrackerContext _context;
        private readonly IGameQueryService _gameQueryService;

        public CharacterQueryService(RoleTrackerContext context, IGameQueryService gameQueryService)
        {
            _context = context;
            _gameQueryService = gameQueryService;
        }

        public async Task<Character?> GetCharacterByIdAsync(int id)
        {
            Character? character = null;
            if(_context.Character is not null)
            {
                character = await _context.Character.FirstOrDefaultAsync(m => m.Id == id);
                Game? game = await _gameQueryService.GetGameByIdAsync(character.GameId);
                if(game is not null)
                {
                    character.Game = game;
                }
            }

            return character;
        }

        public async Task<bool> CharacterExistsAsync(int id)
        {
            if (_context.Character is null)
                return false;

            return await _context.Character.AnyAsync(c => c.Id == id);
        }

        public async Task<List<Character>> GetCharactersAsync()
        {
            var characters = new List<Character>();
            if (_context.Character is not null)
            {
                characters = await _context.Character.ToListAsync();

                var games = await _gameQueryService.GetGamesForSelector();
                //TODO: verificar por qué aparece asignados
                //characters.ForEach(c => c.Game.Name = games.Where(g => g.Value == c.GameId.ToString()).Select(g => g.Text).FirstOrDefault());
            }

            return characters;
        }

        public bool GameOngoingByCharacter(int idGame)
        {
            bool gameOnGoingByCharacter = false;
            if (_context.Character is not null)
            {
                gameOnGoingByCharacter = _context.Character.Any(c => c.GameId == idGame);
            }
            return gameOnGoingByCharacter;
        }
    }
}
