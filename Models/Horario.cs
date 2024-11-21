using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EduCenterManagerDB.Models
{
    public class Horario
    {
        [Key]
        public int IdHorario { get; set; }

        [Required]
        public int IdCurso { get; set; }

        [Required]
        public string DiaSemana { get; set; } = string.Empty;

        [Required]
        public DateTime HoraInicio { get; set; }

        [Required]
        public DateTime HoraFin { get; set; }

        [ForeignKey("IdCurso")]
        public Curso? Curso { get; set; }
    }
}