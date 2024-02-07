using DoctorApp.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models.Models;

namespace DoctorApp.ConfiguracionesModels
{
    public class MedicoConfiguracion : IEntityTypeConfiguration<MedicoModel>
    {
        public void Configure(EntityTypeBuilder<MedicoModel> builder)
        {
            builder.Property(x => x.Id).IsRequired();
            builder.Property(x => x.Apellido).IsRequired().HasMaxLength(60);
            builder.Property(x => x.Nombre).IsRequired().HasMaxLength(60);
            builder.Property(x => x.Direccion).IsRequired().HasMaxLength(100);
            builder.Property(x => x.Telefono).IsRequired(false).HasMaxLength(40);
            builder.Property(x => x.Genero).IsRequired().HasColumnType("char").HasMaxLength(1);
            builder.Property(x => x.Estado).IsRequired();
            builder.Property(x => x.EspecialidadId).IsRequired();

            /* Relaciones */

            builder.HasOne(x => x.Especialidad).WithMany()
                   .HasForeignKey(x => x.EspecialidadId)
                   .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
