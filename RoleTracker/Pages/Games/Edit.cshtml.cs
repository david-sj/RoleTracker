using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RoleTracker.DTO;
using RoleTracker.Models;
using RoleTracker.Services;

namespace RoleTracker.Pages.Games
{
    public class EditModel : PageModel
    {
        private readonly IGameQueryService _gameQueryService;
        private readonly IGameCrudService _gameCrudService;

        public EditModel(IGameQueryService gameQueryService, IGameCrudService gameCrudService)
        {
            _gameQueryService = gameQueryService;
            _gameCrudService = gameCrudService;
        }

        [BindProperty]
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

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var gameCommand = new GameCommand()
            {
                Id = Game.Id,
                Name = Game.Name,
                MasterName = Game.MasterName,
                HoursPlayed = Game.HoursPlayed,
                StartedAt = Game.StartedAt
            };

            try
            {
                await _gameCrudService.EditGameAsync(gameCommand);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await GameExistsAsync(Game.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private async Task<bool> GameExistsAsync(int id)
        {
            return await _gameQueryService.GameExistsAsync(id);
        }
    }
}
