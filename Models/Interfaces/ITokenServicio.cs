using DoctorApp.Models;
using Models.Models;

namespace DoctorApp.Interfaces
{
    public interface ITokenServicio
    {
        Task<string> CrearToken(UsuarioAplicacionModel usuario);

    }
}
