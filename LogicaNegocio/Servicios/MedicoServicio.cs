﻿using AutoMapper;
using DoctorApp.DTOs;
using DoctorApp.Interfaces.IRepositorio;
using DoctorApp.Models;
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
    public class MedicoServicio : IMedicoServicio
    {
        

            private readonly IUnidadTrabajo _unidadTrabajo;
            private readonly IMapper _mapper;

            public MedicoServicio(IUnidadTrabajo unidadTrabajo, IMapper mapper)
            {
                _unidadTrabajo = unidadTrabajo;
                _mapper = mapper;
            }

            public async Task<MedicoDto> Agregar(MedicoDto modeloDto)
            {
                try
                {
                    MedicoModel medico = new MedicoModel
                    {
                        Apellido = modeloDto.Apellido,
                        Nombre = modeloDto.Nombre,
                        Direccion = modeloDto.Direccion,
                        Telefono = modeloDto.Telefono,
                        Genero = modeloDto.Genero,
                        EspecialidadId = modeloDto.EspecialidadId,
                        Estado = modeloDto.Estado == 1 ? true : false,
                        FechaCreacion = DateTime.Now,
                        FechaActualizacion = DateTime.Now
                    };
                    await _unidadTrabajo.Medico.Agregar(medico);
                    await _unidadTrabajo.Guardar();
                    if (medico.Id == 0)
                        throw new TaskCanceledException("El medico no se pudo crear");
                    return _mapper.Map<MedicoDto>(medico);
                }
                catch (Exception)
                {

                    throw;
                }
            }


            public async Task Actualizar(MedicoDto modeloDto)
            {
                try
                {
                    var medicoDb = await _unidadTrabajo.Medico.ObtenerPrimero(e => e.Id == modeloDto.Id);
                    if (medicoDb == null)
                        throw new TaskCanceledException("La medico no existe");

                    medicoDb.Apellido = modeloDto.Apellido;
                    medicoDb.Nombre = modeloDto.Nombre;
                    medicoDb.Estado = modeloDto.Estado == 1 ? true : false;
                    medicoDb.Direccion= modeloDto.Direccion;
                    medicoDb.Telefono = modeloDto.Telefono;
                    medicoDb.Genero = modeloDto.Genero;
                    medicoDb.EspecialidadId = modeloDto.EspecialidadId;
                
                    _unidadTrabajo.Medico.Actualizar(medicoDb);
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
                    var medicoDb = await _unidadTrabajo.Medico.ObtenerPrimero(e => e.Id == id);
                    if (medicoDb == null)
                        throw new TaskCanceledException("El medico no existe");
                    _unidadTrabajo.Medico.Remover(medicoDb);
                    await _unidadTrabajo.Guardar();
                }
                catch (Exception)
                {

                    throw;
                }
            }

            public async Task<IEnumerable<MedicoDto>> ObtenerTodos()
            {
                try
                {
                    var lista = await _unidadTrabajo.Medico.ObtenerTodos(incluirPropiedades:"Especialidad",
                                        orderBy: e => e.OrderBy(e => e.Apellido));
                    return _mapper.Map<IEnumerable<MedicoDto>>(lista);
                }
                catch (Exception)
                {

                    throw;
                }
            }

            public async Task<IEnumerable<MedicoDto>> ObtenerActivos()
            {
                try
                {
                    var lista = await _unidadTrabajo.Medico.ObtenerTodos(x => x.Estado == true,
                                        orderBy: e => e.OrderBy(e => e.Apellido));
                    return _mapper.Map<IEnumerable<MedicoDto>>(lista);
                }
                catch (Exception)
                {

                    throw;
                }
            }
        }
}
