using System.ComponentModel.DataAnnotations;

namespace DoctorApp.DTOs
{
    public class EspecialidadDto
    {
        
        public int Id { get; set; }

        [Required (ErrorMessage = "El nombre es Requerido")]
        [StringLength(60, MinimumLength = 1, ErrorMessage = "El nombre debe ser Minimo 1 Maximo 60 caracteres")]
        public string NombreEspecialidad { get; set; }

        [Required (ErrorMessage = "La descripcion es Requerida")]
        [StringLength(100, MinimumLength = 1, ErrorMessage = "La Descripcion debe ser Minimo 1 Maximo 100 caracteres")]
        public string Descripcion { get; set; }

        [Required(ErrorMessage = "El estado Requerido")]
        public int Estado { get; set; }     //1 - 0
    }
}
