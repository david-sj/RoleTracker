using Microsoft.AspNetCore.Mvc.Rendering;
using RoleTracker.Models;

namespace RoleTracker.Services
{
    public interface ICharacterQueryService
    {
        Task<Character?> GetCharacterByIdAsync(int id);
        Task<bool> CharacterExistsAsync(int id);

    }
}
