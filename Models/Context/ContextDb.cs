using DoctorApp.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Models.Models;
using System.Reflection;

namespace DoctorApp.Context
{
    public class ContextDb : IdentityDbContext<UsuarioAplicacionModel, RolAplicacionModel, int, IdentityUserClaim<int>
                                                         , RolUsuarioAplicacionModel, IdentityUserLogin<int>, IdentityRoleClaim<int>
                                                         , IdentityUserToken<int>>
    {
        public ContextDb(DbContextOptions<ContextDb> options) : base(options) { }
        public DbSet<UsuarioAplicacionModel> UsuariosAplicacion { get; set; }
        public DbSet<UsuarioModels> Usuarios { get; set; }
        public DbSet<EspecialidadModel> Especialidades { get; set;}

        public DbSet<MedicoModel> Medicos { get; set;}
        public DbSet<PacienteModel> Pacientes { get; set; }


        //Un archivo de configuracion por cada entidad que vayamos creando
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

    }
}
