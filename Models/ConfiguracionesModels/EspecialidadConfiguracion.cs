using DoctorApp.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DoctorApp.ConfiguracionesModels
{
    public class EspecialidadConfiguracion : IEntityTypeConfiguration<EspecialidadModel>
    {
        public void Configure(EntityTypeBuilder<EspecialidadModel> builder)
        {
            builder.Property(x => x.Id).IsRequired();
            builder.Property(x => x.NombreEspecialidad).IsRequired().HasMaxLength(60);
            builder.Property(x => x.Descripcion).IsRequired().HasMaxLength(100);
            builder.Property(x => x.Estado).IsRequired();
        }
    }
}
