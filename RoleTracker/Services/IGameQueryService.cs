using Microsoft.AspNetCore.Mvc.Rendering;
using RoleTracker.Models;

namespace RoleTracker.Services
{
    public interface IGameQueryService
    {
        Task<List<SelectListItem>> GetGamesForSelector();
        Task<Game?> GetGameByIdAsync(int id);
        Task<List<Game>> GetGamesAsync();
        Task<bool> GameExistsAsync(int id);

    }
}
