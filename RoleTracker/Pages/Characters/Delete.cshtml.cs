using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RoleTracker.Data;
using RoleTracker.DTO;
using RoleTracker.Models;
using RoleTracker.Services;

namespace RoleTracker.Pages.Characters
{
    public class DeleteModel : PageModel
    {
        private readonly ICharacterQueryService _characterQueryService;
        private readonly ICharacterCrudService _characterCrudService;

        public DeleteModel(ICharacterQueryService characterQueryService,
                         ICharacterCrudService characterCrudService)
        {
            _characterQueryService = characterQueryService;
            _characterCrudService = characterCrudService;
        }

        [BindProperty]
        public Character Character { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id is null)
            {
                return NotFound();
            }

            var character = await _characterQueryService.GetCharacterByIdAsync(id.Value);

            if (character is null)
            {
                return NotFound();
            }

            Character = character;

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id is null)
            {
                return NotFound();
            }

            await _characterCrudService.DeleteCharacterAsync(id.Value);

            return RedirectToPage("./Index");
        }
    }
}
