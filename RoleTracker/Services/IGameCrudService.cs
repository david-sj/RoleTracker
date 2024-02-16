using Microsoft.AspNetCore.Mvc.Rendering;
using RoleTracker.DTO;
using RoleTracker.Models;

namespace RoleTracker.Services
{
    public interface IGameCrudService
    {
        Task CreateGameAsync(GameCommand gameCommand);
        Task DeleteGameAsync(int id);
        Task EditGameAsync(GameCommand gameCommand);
    }
}
