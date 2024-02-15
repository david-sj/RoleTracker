using System.ComponentModel.DataAnnotations.Schema;

namespace RoleTracker.Models
{
    public class Character
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Race { get; set; }
        public string? Player { get; set; }
        public int Level { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int GameId { get; set; }
        public Game Game { get; set; }
    }
}
