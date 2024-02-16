using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RoleTracker.Data;
using RoleTracker.Models;
using RoleTracker.Services;

namespace RoleTracker.Pages.Games
{
    public class IndexModel : PageModel
    {
        private readonly IGameQueryService _gameQueryService;

        public IndexModel(IGameQueryService gameQueryService)
        {
            _gameQueryService = gameQueryService;
        }

        public IList<Game> Game { get; set; } = default!;

        public async Task OnGetAsync()
        {
            Game = await _gameQueryService.GetGamesAsync();
        }
    }
}
