using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RoleTracker.Data;
using RoleTracker.DTO;
using RoleTracker.Models;

namespace RoleTracker.Services
{
    public class CharacterCrudService : ICharacterCrudService
    {
        private readonly RoleTrackerContext _context;

        public CharacterCrudService(RoleTrackerContext context)
        {
            _context = context;
        }

        public async Task EditCharacterAsync(CharacterCommand characterCommand)
        {
            var character = await _context.Character.FirstOrDefaultAsync(c => c.Id == characterCommand.Id);

            if (character is not null)
            {
                character.Name = characterCommand.Name;
                character.Player = characterCommand.Player;
                character.Level = characterCommand.Level;
                character.Race = characterCommand.Race;
                character.GameId = characterCommand.GameId;

                _context.Attach(character).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }
        }

        public async Task DeleteCharacterAsync(int id)
        {
            var character = await _context.Character.FirstOrDefaultAsync(c => c.Id == id);

            if (character is not null)
            {
                _context.Character.Remove(character);
                await _context.SaveChangesAsync();
            }
        }

        public async Task CreateCharacterAsync(CharacterCommand characterCommand)
        {
            if (characterCommand is not null)
            {
                var newCharacter = new Character()
                {
                    Id = characterCommand.Id,
                    Name = characterCommand.Name,
                    Player = characterCommand.Player,
                    Level = characterCommand.Level,
                    Race = characterCommand.Race,
                    GameId = characterCommand.GameId
                };

                _context.Character.Add(newCharacter);
                await _context.SaveChangesAsync();
            }
        }
    }
}
