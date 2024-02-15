using Microsoft.AspNetCore.Mvc.Rendering;
using RoleTracker.DTO;
using RoleTracker.Models;

namespace RoleTracker.Services
{
    public interface ICharacterCrudService
    {
        Task SaveCharacterAsync(CharacterCommand characterCommand);

    }
}
