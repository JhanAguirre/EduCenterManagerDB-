using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EduCenterManagerDB.Models
{
    public class Curso
    {
        [Key]
        public int IdCurso { get; set; }

        [Required]
        public string NombreCurso { get; set; } = string.Empty;

        [Required]
        public string Descripcion { get; set; } = string.Empty;

        [Required]
        public int IdProfesor { get; set; }

        [ForeignKey("IdProfesor")]
        public Profesor? Profesor { get; set; }
    }
}