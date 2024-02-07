using DoctorApp.Models;
using Models.Models;

namespace DoctorApp.Interfaces.IRepositorio
{
    public interface IMedicoRepositorio : IRepositorioGenerico<MedicoModel>
    {
        void Actualizar(MedicoModel medico);
    }
}
