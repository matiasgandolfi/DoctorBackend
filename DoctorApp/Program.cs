using DoctorApp.Context;
using DoctorApp.Extensiones;
using DoctorApp.Interfaces;
using DoctorApp.Middleware;
using DoctorApp.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Models.DTOs;
using Models.Inicializador;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddScoped<ApiResponse>();


builder.Services.AgregarServiciosAplicacion(builder.Configuration);
builder.Services.AgregarServiciosIdentidad(builder.Configuration);
builder.Services.AddScoped<IdbInicializador, DbInicializador>();

//****************************************************************************************

builder.Services.AddDbContext<ContextDb>(
    options =>
    {
        options.UseSqlServer(builder.Configuration.GetConnectionString("ConnectionStr"));

    });


//****************************************************************************************



var app = builder.Build();

// Configure the HTTP request pipeline.


app.UseMiddleware<ExceptionMiddleware>();



if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseCors(x => x.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());

app.UseAuthentication();
app.UseAuthorization();


using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var loggerFactory = services.GetRequiredService<ILoggerFactory>();
    try
    {
        var inicializador = services.GetRequiredService<IdbInicializador>();
        inicializador.Inicializar();
    }
    catch (Exception ex)
    {

        var logger = loggerFactory.CreateLogger<Program>();
        logger.LogError(ex, "Un Error ocurrio al ejecutar la migracion");
    }
}

app.MapControllers();

app.Run();
