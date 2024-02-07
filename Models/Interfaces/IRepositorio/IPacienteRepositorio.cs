using DoctorApp.Interfaces.IRepositorio;
using Models.Models;

namespace Models.Interfaces.IRepositorio
{
    public interface IPacienteRepositorio : IRepositorioGenerico<PacienteModel>
    {
        void Actualizar(PacienteModel paciente);
    }
}