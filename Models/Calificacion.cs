using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EduCenterManagerDB.Models
{
    public class Calificacion
    {
        [Key]
        public int IdCalificacion { get; set; }

        [Required]
        public int IdEstudiante { get; set; }

        [Required]
        public int IdCurso { get; set; }

        [Required]
        [Column(TypeName = "decimal(5,2)")]
        public decimal Nota { get; set; }

        [Required]
        public DateTime Fecha { get; set; }

        [ForeignKey("IdEstudiante")]
        public Estudiante? Estudiante { get; set; }

        [ForeignKey("IdCurso")]
        public Curso? Curso { get; set; }
    }
}