using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.ConfiguracionesModels
{
    public class PacienteConfiguracion : IEntityTypeConfiguration<PacienteModel>
    {
        public void Configure(EntityTypeBuilder<PacienteModel> builder)
        {
            builder.Property(x => x.Id).IsRequired();
            builder.Property(x => x.Nombre).IsRequired().HasMaxLength(60);
            builder.Property(x => x.Apellido).IsRequired().HasMaxLength(60);
            builder.Property(x => x.FechaDeNacimiento).IsRequired();
            builder.Property(x => x.Genero).IsRequired().HasColumnType("char").HasMaxLength(1);
            builder.Property(x => x.Direccion).IsRequired().HasMaxLength(100);
            builder.Property(x => x.Telefono).IsRequired(false).HasMaxLength(20);
            builder.Property(x => x.Email).IsRequired(false).HasMaxLength(100);
            builder.Property(x => x.HistorialMedico).IsRequired(false).HasMaxLength(500);
            builder.Property(x => x.Estado).IsRequired();
            builder.Property(x => x.FechaCreacion).IsRequired();
            builder.Property(x => x.FechaActualizacion).IsRequired();

            // Aquí puedes agregar cualquier configuración adicional para relaciones 
            // si PacienteModel tiene relaciones con otras entidades
        }
    }
}
