using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RoleTracker.Models
{
    public class Game
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre de la partida es obligatorio")]
        [StringLength(50, ErrorMessage = "El nombre no puede superar los 50 caracteres.")]
        [Display(Name = "Nombre")]
        public string Name { get; set; }

        [Required(ErrorMessage = "El nombre del master es obligatorio")]
        [StringLength(50, ErrorMessage = "El nombre no puede superar los 50 caracteres.")]
        [Display(Name = "Master")]
        public string MasterName { get; set; }

        [Required(ErrorMessage = "El número de horas jugadas es obligatorio")]
        [Range(0, int.MaxValue, ErrorMessage = "Solo se permiten números positivos")]
        [Display(Name = "Horas de juego")]
        public int HoursPlayed { get; set; }

        [Required(ErrorMessage = "El día de inicio de la partida es obligatorio")]
        [DataType(DataType.Date)]
        [Display(Name = "Día de inicio")]
        public DateTime StartedAt { get; set; }

    }
}
