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
        private readonly RoleTracker.Data.RoleTrackerContext _context;
        private readonly IGameQueryService _gameQueryService;
        private readonly ICharacterQueryService _characterQueryService;
        private readonly ICharacterCrudService _characterCrudService;

        public DetailsModel(RoleTracker.Data.RoleTrackerContext context,
                            IGameQueryService gameQueryService,
                            ICharacterQueryService characterQueryService,
                            ICharacterCrudService characterCrudService)
        {
            _context = context;
            _gameQueryService = gameQueryService;
            _characterQueryService = characterQueryService;
            _characterCrudService = characterCrudService;
        }

      public Character Character { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (!id.HasValue)
            {
                return NotFound();
            }

            var character = await _characterQueryService.GetCharacterByIdAsync(id.Value);

            //recuperar el nom del game

            if (character is null)
            {
                return NotFound();
            }

            Character = character;

            return Page();
        }
    }
}
