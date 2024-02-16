using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using RoleTracker.Data;
using RoleTracker.DTO;
using RoleTracker.Models;
using RoleTracker.Services;

namespace RoleTracker.Pages.Characters
{
    public class CreateModel : PageModel
    {
        private readonly ICharacterCrudService _characterCrudService;
        private readonly IGameQueryService _gameQueryService;

        public CreateModel(ICharacterCrudService characterCrudService, IGameQueryService gameQueryService)
        {
            _characterCrudService = characterCrudService;
            _gameQueryService = gameQueryService;
        }

        public List<SelectListItem> Games { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            Games = await _gameQueryService.GetGamesForSelector();

            return Page();
        }

        [BindProperty]
        public Character Character { get; set; } = default!;
       
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid || Character is null)
            {
                return Page();
            }

            var characterCommand = new CharacterCommand()
            {
                Id = Character.Id,
                Name = Character.Name,
                Player = Character.Player,
                Race = Character.Race,
                Level = Character.Level,
                GameId = Character.GameId
            };

            await _characterCrudService.CreateCharacterAsync(characterCommand);

            return RedirectToPage("./Index");
        }
    }
}
