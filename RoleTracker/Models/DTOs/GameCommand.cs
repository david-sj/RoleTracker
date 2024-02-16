using System.ComponentModel.DataAnnotations;

namespace RoleTracker.DTO
{
    public class GameCommand
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string MasterName { get; set; }
        public int HoursPlayed { get; set; }
        public DateTime StartedAt { get; set; }
    }
}
