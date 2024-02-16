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

namespace RoleTracker.Pages.Characters
{
    public class IndexModel : PageModel
    {
        private readonly ICharacterQueryService _characterQueryService;

        public IndexModel(ICharacterQueryService characterQueryService)
        {
            _characterQueryService = characterQueryService;
        }

        public IList<Character> Character { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Character = await _characterQueryService.GetCharactersAsync();
        }
    }
}
