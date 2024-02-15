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

        public async Task SaveCharacterAsync(CharacterCommand characterCommand)
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
    }
}
