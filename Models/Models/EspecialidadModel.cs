﻿using System.ComponentModel.DataAnnotations;

namespace DoctorApp.Models
{
    public class EspecialidadModel
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(60, MinimumLength = 1, ErrorMessage = "El Nombre debe ser Minimo 1 Maximo 60 caracteres")]
        public string NombreEspecialidad { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 1, ErrorMessage = "La Descripcion debe ser Minimo 1 Maximo 100 caracteres")]
        public string Descripcion { get; set; }

        public bool Estado { get; set; }

        public DateTime FechaCreacion { get; set; }
        public DateTime FechaActualizacion { get; set; }

    }
}