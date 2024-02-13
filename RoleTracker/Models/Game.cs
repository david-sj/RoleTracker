using System.ComponentModel.DataAnnotations;

namespace RoleTracker.Models
{
    public class Game
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? MasterName { get; set; }
        public int HoursPlayed { get; set; }
        [DataType(DataType.Date)]
        public DateTime StartedAt { get; set; }

    }
}
