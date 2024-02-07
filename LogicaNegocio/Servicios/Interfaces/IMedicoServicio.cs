using DoctorApp.DTOs;
using Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.Servicios.Interfaces
{
    public interface IMedicoServicio
    {
        Task<IEnumerable<MedicoDto>> ObtenerTodos();
        Task<MedicoDto> Agregar(MedicoDto modelDto);
        Task Actualizar(MedicoDto modelDto);
        Task Remover(int id);
    }
}
