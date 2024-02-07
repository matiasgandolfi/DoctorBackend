using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Models
{
    public class PacienteModel
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre es requerido")]
        [StringLength(60, MinimumLength = 2, ErrorMessage = "El nombre debe tener entre 2 y 60 caracteres")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "El apellido es requerido")]
        [StringLength(60, MinimumLength = 2, ErrorMessage = "El apellido debe tener entre 2 y 60 caracteres")]
        public string Apellido { get; set; }

        [Required(ErrorMessage = "La fecha de nacimiento es requerida")]
        public DateTime FechaDeNacimiento { get; set; }

        [Required(ErrorMessage = "El género es requerido")]
        public char Genero { get; set; }

        [Required(ErrorMessage = "La dirección es requerida")]
        [StringLength(100, ErrorMessage = "La dirección no debe exceder los 100 caracteres")]
        public string Direccion { get; set; }

        [StringLength(20, ErrorMessage = "El teléfono no debe exceder los 20 caracteres")]
        public string Telefono { get; set; }

        [EmailAddress(ErrorMessage = "El formato del email no es válido")]
        public string Email { get; set; }

        [StringLength(500, ErrorMessage = "El historial médico no debe exceder los 500 caracteres")]
        public string HistorialMedico { get; set; }

        public bool Estado { get; set; }

        public DateTime FechaCreacion { get; set; }
        public DateTime FechaActualizacion { get; set; }
    }
}
