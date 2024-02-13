namespace RoleTracker.Models
{
    public class Character
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Race { get; set; }
        public string? Player { get; set; }
        public int Level { get; set; }
        public int GameId { get; set; }
    }
}
