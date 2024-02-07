using DoctorApp.Context;
using DoctorApp.Controllers.Errores;
using DoctorApp.Interfaces;
using DoctorApp.Interfaces.IRepositorio;
using DoctorApp.Repositorio;
using DoctorApp.Services;
using LogicaNegocio.Servicios;
using LogicaNegocio.Servicios.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Models.DTOs;
using Utilidades;

namespace DoctorApp.Extensiones
{
    public static class ServicioAplicacionExtension
    {


        public static IServiceCollection AgregarServiciosAplicacion(this IServiceCollection services, IConfiguration config)
        {

            /*-------------------------  Swagger  --------------------------------------------------*/
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen(options =>
            {
                options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = "Ingresar Bearer [espacio] token \r \n \r \n" +
                                "Ejemplo: Bearer ejoy^8878899999900000",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Scheme = "Bearer"
                });
                options.AddSecurityRequirement(new OpenApiSecurityRequirement()
                    {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            },

                            Scheme = "oauth2",
                            Name = "Bearer",
                            In = ParameterLocation.Header
                        },
                        new List<string>()
                    }
                    });
            });









            /*----------------------------- DbContext -----------------------------------*/



            services.AddDbContext<ContextDb>(
                options =>
                {
                    options.UseSqlServer(config.GetConnectionString("ConnectionStr"));

                });




            /*-------------------------Servicios ------------------------------------*/
            services.AddScoped<ApiResponse>();
            services.AddScoped<ITokenServicio, TokenServicio>();
            services.Configure<ApiBehaviorOptions>(options =>
            {
                options.InvalidModelStateResponseFactory = actionContext =>
                {
                    var errores = actionContext.ModelState
                                  .Where(e => e.Value.Errors.Count > 0)
                                  .SelectMany(x => x.Value.Errors)
                                  .Select(x => x.ErrorMessage).ToArray();



                    var errorResponse = new ApiValidacionErrorResponse
                    {
                        Errores = errores
                    };
                    return new BadRequestObjectResult(errorResponse);
                };
            });

            services.AddScoped<IUnidadTrabajo, UnidadTrabajo>();
            services.AddAutoMapper(typeof(MappingProfile));

            services.AddScoped<IEspecialidadServicio, EspecialidadServicio>();
            services.AddScoped<IMedicoServicio, MedicoServicio>();
            services.AddScoped<IPacienteServicio, PacienteServicio>();


            return services;
        }
    }
}

