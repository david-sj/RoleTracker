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

namespace RoleTracker.Pages.Games
{
    public class CreateModel : PageModel
    {
        /*private readonly RoleTracker.Data.RoleTrackerContext _context;

        public CreateModel(RoleTracker.Data.RoleTrackerContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Game Game { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Game == null || Game == null)
            {
                return Page();
            }

            _context.Game.Add(Game);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }*/

        private readonly IGameCrudService _gameCrudService;

        public CreateModel(IGameCrudService gameCrudService)
        {
            _gameCrudService = gameCrudService;
        }

        public List<SelectListItem> Games { get; set; }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Game Game { get; set; } = default!;

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid || Game is null)
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

            await _gameCrudService.CreateGameAsync(gameCommand);

            return RedirectToPage("./Index");
        }
    }
}
