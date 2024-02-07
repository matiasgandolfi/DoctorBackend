using DoctorApp.Context;
using DoctorApp.Interfaces.IRepositorio;
using DoctorApp.Models;
using DoctorApp.Repositorio;
using Models.Interfaces.IRepositorio;
using Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Repositorio
{
    public class PacienteRepositorio : Repositorio<PacienteModel>, IPacienteRepositorio
    {
        private readonly ContextDb _db;

        public PacienteRepositorio(ContextDb db) : base(db)
        {
            _db = db;
        }

        public void Actualizar(PacienteModel paciente)
        {
            var pacienteDb = _db.Pacientes.FirstOrDefault(p => p.Id == paciente.Id);
            if (pacienteDb != null)
            {
                pacienteDb.Nombre = paciente.Nombre;
                pacienteDb.Apellido = paciente.Apellido;
                pacienteDb.FechaDeNacimiento = paciente.FechaDeNacimiento;
                pacienteDb.Genero = paciente.Genero;
                pacienteDb.Direccion = paciente.Direccion;
                pacienteDb.Telefono = paciente.Telefono;
                pacienteDb.Email = paciente.Email;
                pacienteDb.HistorialMedico = paciente.HistorialMedico;
                pacienteDb.Estado = paciente.Estado;
                pacienteDb.FechaActualizacion = DateTime.Now;

                _db.SaveChanges();
            }
        }
    }
}
