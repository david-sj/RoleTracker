using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RoleTracker.Models;

namespace RoleTracker.Data
{
    public class RoleTrackerContext : DbContext
    {
        public RoleTrackerContext (DbContextOptions<RoleTrackerContext> options)
            : base(options)
        {
        }

        public DbSet<RoleTracker.Models.Game> Game { get; set; } = default!;

        public DbSet<RoleTracker.Models.Character>? Character { get; set; }
    }
}
