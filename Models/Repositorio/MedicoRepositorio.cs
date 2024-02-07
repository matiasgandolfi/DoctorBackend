using DoctorApp.Context;
using DoctorApp.Interfaces.IRepositorio;
using DoctorApp.Models;
using Models.Models;
using System.Linq.Expressions;

namespace DoctorApp.Repositorio
{
    public class MedicoRepositorio : Repositorio<MedicoModel>, IMedicoRepositorio
    {
        private readonly ContextDb _db;

        public MedicoRepositorio(ContextDb db) : base(db)
        {
            _db = db;
        }

        public void Actualizar(MedicoModel medico)
        {
            var medicoDb = _db.Medicos.FirstOrDefault(e => e.Id == medico.Id);
            if (medicoDb != null)
            {
                medicoDb.Apellido = medico.Apellido;
                medicoDb.Nombre = medico.Nombre;
                medicoDb.Estado = medico.Estado;
                medicoDb.FechaActualizacion = DateTime.Now;
                medicoDb.Genero = medico.Genero;
                medicoDb.Especialidad = medico.Especialidad;
                medicoDb.Direccion = medico.Direccion;
                _db.SaveChanges();
            }
        }
    }
}
