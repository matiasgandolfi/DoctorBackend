using DoctorApp.Context;
using DoctorApp.Interfaces.IRepositorio;
using Models.Interfaces.IRepositorio;
using Models.Repositorio;

namespace DoctorApp.Repositorio
{
    public class UnidadTrabajo : IUnidadTrabajo
    {
        private readonly ContextDb _db;
        public IEspecialidadRepositorio Especialidad { get; private set; }
        public IMedicoRepositorio Medico { get; private set; }
        public IPacienteRepositorio Paciente { get; private set; }


        public UnidadTrabajo(ContextDb db)
        {
            _db = db;
            Especialidad = new EspecialidadRepositorio(db);
            Medico = new MedicoRepositorio(db);
            Paciente = new PacienteRepositorio(db);
        }



        public void Dispose()
        {
            _db.Dispose();
        }

        public async Task Guardar()
        {
            await _db.SaveChangesAsync();
        }

    }
}
