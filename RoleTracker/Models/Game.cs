using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RoleTracker.Models
{
    public class Game
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "Name cannot be longer than 50 characters.")]
        [Display(Name = "Nombre")]
        public string Name { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "First name cannot be longer than 50 characters.")]
        [Display(Name = "Master")]
        public string MasterName { get; set; }

        [Required]
        [Display(Name = "Horas de juego")]
        public int HoursPlayed { get; set; }

        [DataType(DataType.Date)]
        [Required]
        [Display(Name = "Día de inicio")]
        public DateTime StartedAt { get; set; }

    }
}
