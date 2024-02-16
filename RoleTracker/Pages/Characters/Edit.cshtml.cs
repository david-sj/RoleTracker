using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using RoleTracker.Data;
using RoleTracker.DTO;
using RoleTracker.Models;
using RoleTracker.Services;

namespace RoleTracker.Pages.Characters
{
    public class EditModel : PageModel
    {
        private readonly IGameQueryService _gameQueryService;
        private readonly ICharacterQueryService _characterQueryService;
        private readonly ICharacterCrudService _characterCrudService;

        public EditModel(IGameQueryService gameQueryService,
                         ICharacterQueryService characterQueryService,
                         ICharacterCrudService characterCrudService)
        {
            _gameQueryService = gameQueryService;
            _characterQueryService = characterQueryService;
            _characterCrudService = characterCrudService;
        }

        [BindProperty]
        public Character Character { get; set; } = default!;

        public List<SelectListItem> Games { get; set; }
        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id is null)
            {
                return NotFound();
            }

            var character = await _characterQueryService.GetCharacterByIdAsync(id.Value);
            Games = await _gameQueryService.GetGamesForSelector();

            if (character is null)
            {
                return NotFound();
            }
            Character = character;

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
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

            try
            {
                await _characterCrudService.EditCharacterAsync(characterCommand);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await CharacterExistsAsync(Character.Id))
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

        private async Task<bool> CharacterExistsAsync(int id)
        {
          return await _characterQueryService.CharacterExistsAsync(id);
        }
    }
}
