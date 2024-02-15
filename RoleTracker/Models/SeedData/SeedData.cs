using Microsoft.EntityFrameworkCore;
using RoleTracker.Data;

namespace RoleTracker.Models.SeedData
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new RoleTrackerContext(serviceProvider.GetRequiredService<DbContextOptions<RoleTrackerContext>>()))
            {
                if (context == null || context.Game == null || context.Character == null)
                {
                    throw new ArgumentNullException("Null RazorPagesMovieContext");
                }

                if (context.Game.Any() && context.Character.Any())
                {
                    return;
                }

                var newGame = new Game
                {
                    Id = 1,
                    Name = "Misión por Poble Sec",
                    MasterName = "David Siurana",
                    HoursPlayed = 2,
                    StartedAt = new DateTime(2024, 02, 01)
                };

                context.Game.AddRange( newGame );

                context.Character.AddRange(
                    new Character
                    {
                        Id = 1,
                        Name = "Gimli",
                        Race = "Dwarf",
                        Player = "Juan",
                        Level = 1,
                        GameId = 1,
                        Game = newGame
                    },
                    new Character
                    {
                        Id = 2,
                        Name = "Legolas",
                        Race = "Elf",
                        Player = "Ana",
                        Level = 1,
                        GameId = 1,
                        Game = newGame
                    }
                );

                context.SaveChanges();
            }
        }
    }
}
