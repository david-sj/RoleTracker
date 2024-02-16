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
    public class DetailsModel : PageModel
    {
        private readonly IGameQueryService _gameQueryService;

        public DetailsModel(IGameQueryService gameQueryService)
        {
            _gameQueryService = gameQueryService;
        }

        public Game Game { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id is null)
            {
                return NotFound();
            }

            var game = await _gameQueryService.GetGameByIdAsync(id.Value);

            if (game is null)
            {
                return NotFound();
            }

            Game = game;

            return Page();
        }
    }
}
