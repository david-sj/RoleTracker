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
using static System.Net.Mime.MediaTypeNames;

namespace RoleTracker.Pages.Characters
{
    public class DetailsModel : PageModel
    {
        private readonly ICharacterQueryService _characterQueryService;

        public DetailsModel(ICharacterQueryService characterQueryService)
        {
            _characterQueryService = characterQueryService;
        }

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
    }
}
