using Models.DTOs;

namespace LogicaNegocio.Servicios.Interfaces
{
    public interface IPacienteServicio
    {
        Task Actualizar(PacienteDto modeloDto);
        Task<PacienteDto> Agregar(PacienteDto modeloDto);
        Task<IEnumerable<PacienteDto>> ObtenerActivos();
        Task<IEnumerable<PacienteDto>> ObtenerTodos();
        Task Remover(int id);
    }
}