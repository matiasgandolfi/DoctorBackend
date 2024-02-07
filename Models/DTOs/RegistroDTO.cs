using System.ComponentModel.DataAnnotations;

namespace DoctorApp.DTOs
{
    public class RegistroDTO
    {
        [Required(ErrorMessage = "Username es Requerido")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Password es Requerido")]
        [StringLength(10, MinimumLength = 4, ErrorMessage = "El password debe ser Minimo 4 Maximo 10 caracteres")]
        public string Password { get; set; }


        [Required(ErrorMessage = "Apellido es Requerido")]
        public string Apellido { get; set; }

        [Required(ErrorMessage = "Nombre es Requerido")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "Email es Requerido")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Rol es Requerido")]
        public string Rol { get; set; }
    }
}
