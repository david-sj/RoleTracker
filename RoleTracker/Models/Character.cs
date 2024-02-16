using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Linq;

namespace RoleTracker.Models
{
    public class Character
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "El nombre no puede ser mayor de 50 caracteres.")]
        [Display(Name = "Nombre")]
        public string Name { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "La raza no puede esr mayor de 20 caracteres.")]
        [Display(Name = "Raza")]
        public string Race { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "El nombre del jugador no puede ser mayor de 50 caracteres.")]
        [Display(Name = "Jugador")]
        public string Player { get; set; }

        [Required]
        [Display(Name = "Nivel")]
        public int Level { get; set; }

        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int GameId { get; set; }
        [Display(Name = "Partida")]
        public Game? Game { get; set; }
    }
}
