using AutoMapper;
using DoctorApp.Interfaces.IRepositorio;
using LogicaNegocio.Servicios.Interfaces;
using Models.DTOs;
using Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.Servicios
{
    public class PacienteServicio : IPacienteServicio
    {
        private readonly IUnidadTrabajo _unidadTrabajo;
        private readonly IMapper _mapper;

        public PacienteServicio(IUnidadTrabajo unidadTrabajo, IMapper mapper)
        {
            _unidadTrabajo = unidadTrabajo;
            _mapper = mapper;
        }

        public async Task<PacienteDto> Agregar(PacienteDto modeloDto)
        {
            try
            {
                var paciente = _mapper.Map<PacienteModel>(modeloDto);
                paciente.FechaCreacion = DateTime.Now;
                paciente.FechaActualizacion = DateTime.Now;

                await _unidadTrabajo.Paciente.Agregar(paciente);
                await _unidadTrabajo.Guardar();

                if (paciente.Id == 0)
                    throw new TaskCanceledException("El paciente no se pudo crear");

                return _mapper.Map<PacienteDto>(paciente);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task Actualizar(PacienteDto modeloDto)
        {
            try
            {
                var pacienteDb = await _unidadTrabajo.Paciente.ObtenerPrimero(p => p.Id == modeloDto.Id);
                if (pacienteDb == null)
                    throw new TaskCanceledException("El paciente no existe");

                _mapper.Map(modeloDto, pacienteDb);
                pacienteDb.FechaActualizacion = DateTime.Now;

                _unidadTrabajo.Paciente.Actualizar(pacienteDb);
                await _unidadTrabajo.Guardar();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task Remover(int id)
        {
            try
            {
                var pacienteDb = await _unidadTrabajo.Paciente.ObtenerPrimero(p => p.Id == id);
                if (pacienteDb == null)
                    throw new TaskCanceledException("El paciente no existe");

                _unidadTrabajo.Paciente.Remover(pacienteDb);
                await _unidadTrabajo.Guardar();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<IEnumerable<PacienteDto>> ObtenerTodos()
        {
            try
            {
                var lista = await _unidadTrabajo.Paciente.ObtenerTodos(orderBy: p => p.OrderBy(p => p.Apellido));
                return _mapper.Map<IEnumerable<PacienteDto>>(lista);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<IEnumerable<PacienteDto>> ObtenerActivos()
        {
            try
            {
                var lista = await _unidadTrabajo.Paciente.ObtenerTodos(x => x.Estado == true,
                                    orderBy: p => p.OrderBy(p => p.Apellido));
                return _mapper.Map<IEnumerable<PacienteDto>>(lista);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
