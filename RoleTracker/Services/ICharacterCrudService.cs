using Microsoft.AspNetCore.Mvc.Rendering;
using RoleTracker.DTO;
using RoleTracker.Models;

namespace RoleTracker.Services
{
    public interface ICharacterCrudService
    {
        Task EditCharacterAsync(CharacterCommand characterCommand);
        Task DeleteCharacterAsync(int id);
        Task CreateCharacterAsync(CharacterCommand characterCommand);
    }
}
