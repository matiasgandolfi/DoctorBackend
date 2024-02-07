using DoctorApp.Context;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using Models.Models;
using System.Text;

namespace DoctorApp.Extensiones
{
    public static class ServicioIdentidadExtension
    { 
            public static IServiceCollection AgregarServiciosIdentidad(this IServiceCollection services, IConfiguration config)
            {
            services.AddIdentityCore<UsuarioAplicacionModel>(opt =>
            {
                opt.Password.RequireNonAlphanumeric = false;
            })
                .AddRoles<RolAplicacionModel>()
                .AddRoleManager<RoleManager<RolAplicacionModel>>()
                .AddEntityFrameworkStores<ContextDb>();


            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["TokenKey"])),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });

            services.AddAuthorization(opt =>
            {
                opt.AddPolicy("AdminRol", policy => policy.RequireRole("Admin"));
                opt.AddPolicy("AdminAgendadorRol", policy => policy.RequireRole("Admin","Agendador"));
                opt.AddPolicy("AdminDoctorRol", policy => policy.RequireRole("Admin", "Doctor"));

            });

            return services;
        }
    }
}
