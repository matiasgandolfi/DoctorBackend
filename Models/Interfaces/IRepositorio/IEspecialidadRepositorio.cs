using DoctorApp.Models;

namespace DoctorApp.Interfaces.IRepositorio
{
    public interface IEspecialidadRepositorio : IRepositorioGenerico<EspecialidadModel>
    {
        void Actualizar(EspecialidadModel especialidad);
    }
}
