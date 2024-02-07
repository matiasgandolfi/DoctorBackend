using DoctorApp.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DTOs
{
    public class MedicoDto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Apellidos es Requerido")]
        [StringLength(60, MinimumLength = 1, ErrorMessage = "Apellido debe ser ser Minimo 1 Maximo 60 caracteres")]
        public string Apellido { get; set; }

        [Required(ErrorMessage = "Nombre es Requerido")]
        [StringLength(60, MinimumLength = 1, ErrorMessage = "Nombre debe ser ser Minimo 1 Maximo 60 caracteres")]
        public string Nombre { get; set; }


        [Required(ErrorMessage = "Direccion es Requerido")]
        [StringLength(100, MinimumLength = 1, ErrorMessage = "Direccion debe ser ser Minimo 1 Maximo 60 caracteres")]
        public string Direccion { get; set; }



        [MaxLength(40)]
        public string Telefono { get; set; }



        [Required(ErrorMessage = "Genero es Requerido")]
        public char Genero { get; set; }

        [Required(ErrorMessage = "Especialidad es Requerida")]
        public int EspecialidadId { get; set; }


        public string NombreEspecialidad { get; set; }


        public int Estado { get; set; }     //1 0
    }
}
