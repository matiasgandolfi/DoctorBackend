using DoctorApp.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.Servicios.Interfaces
{
    public interface IEspecialidadServicio
    {
        Task<IEnumerable<EspecialidadDto>> ObtenerTodos();
        Task<IEnumerable<EspecialidadDto>> ObtenerActivos();

        Task<EspecialidadDto> Agregar(EspecialidadDto modelDto);
        Task Actualizar(EspecialidadDto modelDto);
        Task Remover(int id);
    }
}
