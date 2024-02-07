using DoctorApp.Context;
using DoctorApp.Interfaces.IRepositorio;
using DoctorApp.Models;
using System.Linq.Expressions;

namespace DoctorApp.Repositorio
{
    public class EspecialidadRepositorio : Repositorio<EspecialidadModel>, IEspecialidadRepositorio
    {
        private readonly ContextDb _db;

        public EspecialidadRepositorio(ContextDb db) : base(db)
        {
            _db = db;
        }

        public void Actualizar(EspecialidadModel especialidad)
        {
            var especialidadDb = _db.Especialidades.FirstOrDefault(e => e.Id == especialidad.Id);
            if (especialidadDb != null)
            {
                especialidadDb.NombreEspecialidad = especialidad.NombreEspecialidad;
                especialidadDb.Descripcion = especialidad.Descripcion;
                especialidadDb.Estado = especialidad.Estado;
                especialidadDb.FechaActualizacion = DateTime.Now;
                _db.SaveChanges();
            }
        }
    }
}
