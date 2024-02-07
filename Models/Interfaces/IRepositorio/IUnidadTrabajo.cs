using Models.Interfaces.IRepositorio;

namespace DoctorApp.Interfaces.IRepositorio
{
    public interface IUnidadTrabajo : IDisposable       //IDisposable permite liberar memoria
    {
        IEspecialidadRepositorio Especialidad { get; }
        IMedicoRepositorio Medico { get; }
        IPacienteRepositorio Paciente { get; }

        Task Guardar();

    }
}
