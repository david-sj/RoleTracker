using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RoleTracker.Data;
using RoleTracker.Models;

namespace RoleTracker.Services
{
    public class CharacterQueryService : ICharacterQueryService
    {
        private readonly RoleTrackerContext _context;

        public CharacterQueryService(RoleTrackerContext context)
        {
            _context = context;
        }

        public async Task<Character?> GetCharacterByIdAsync(int id)
        {
            Character? character = null;
            if(_context.Character is not null)
            {
                character = await _context.Character.FirstOrDefaultAsync(m => m.Id == id);
            }

            return character;
        }

        public async Task<bool> CharacterExistsAsync(int id)
        {
            if (_context.Character is null)
                return false;

            return await _context.Character.AnyAsync(c => c.Id == id);
        }
    }
}
