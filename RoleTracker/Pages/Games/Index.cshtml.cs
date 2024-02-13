using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RoleTracker.Data;
using RoleTracker.Models;

namespace RoleTracker.Pages.Games
{
    public class IndexModel : PageModel
    {
        private readonly RoleTracker.Data.RoleTrackerContext _context;

        public IndexModel(RoleTracker.Data.RoleTrackerContext context)
        {
            _context = context;
        }

        public IList<Game> Game { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Game != null)
            {
                Game = await _context.Game.ToListAsync();
            }
        }
    }
}
