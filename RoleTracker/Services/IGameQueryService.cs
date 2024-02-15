using Microsoft.AspNetCore.Mvc.Rendering;

namespace RoleTracker.Services
{
    public interface IGameQueryService
    {
        Task<List<SelectListItem>> GetGamesForSelector();

    }
}
