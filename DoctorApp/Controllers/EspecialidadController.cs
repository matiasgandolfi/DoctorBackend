﻿using DoctorApp.DTOs;
using LogicaNegocio.Servicios.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models.DTOs;
using System.Net;

namespace DoctorApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Policy = "AdminAgendadorRol")]
    public class EspecialidadController : ControllerBase
    {
        private readonly IEspecialidadServicio _especialidadServicio;
        private ApiResponse _response;

        public EspecialidadController(IEspecialidadServicio especialidadServicio, ApiResponse response)
        {
            _especialidadServicio = especialidadServicio;
            _response = new();
        }


        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                _response.Resultado = await _especialidadServicio.ObtenerTodos();
                _response.IsExitoso = true;
                _response.StatusCode = HttpStatusCode.OK;
            }
            catch (Exception ex)
            {
                _response.IsExitoso= false;
                _response.Mensaje = ex.Message;
                _response.StatusCode = HttpStatusCode.BadRequest;
            }
            return Ok(_response);
        }



        [HttpGet("ListadoActivos")]
        public async Task<IActionResult> GetActivos()
        {
            try
            {
                _response.Resultado = await _especialidadServicio.ObtenerActivos();
                _response.IsExitoso = true;
                _response.StatusCode = HttpStatusCode.OK;
            }
            catch (Exception ex)
            {
                _response.IsExitoso = false;
                _response.Mensaje = ex.Message;
                _response.StatusCode = HttpStatusCode.BadRequest;
            }
            return Ok(_response);
        }




        [HttpPost]
        public async Task<IActionResult> Crear(EspecialidadDto modelDto)
        {
            try
            {
                await _especialidadServicio.Agregar(modelDto);
                _response.IsExitoso = true;
                _response.StatusCode = HttpStatusCode.Created;
            }
            catch(Exception ex)
            {
                _response.IsExitoso = false;
                _response.Mensaje= ex.Message;
                _response.StatusCode = HttpStatusCode.BadRequest;
            }
            return Ok(_response);
        }


        [HttpPut]
        public async Task<IActionResult> Editar(EspecialidadDto modelDto)
        {
            try
            {
                await _especialidadServicio.Actualizar(modelDto);
                _response.IsExitoso = true;
                _response.StatusCode = HttpStatusCode.NoContent;
            }
            catch (Exception ex)
            {
                _response.IsExitoso= false;
                _response.Mensaje= ex.Message;
                _response.StatusCode = HttpStatusCode.BadRequest;
            }
            return Ok(_response);
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Eliminar(int id)
        {
            try
            {
                await _especialidadServicio.Remover(id);
                _response.IsExitoso = true;
                _response.StatusCode= HttpStatusCode.NoContent;
            }
            catch(Exception ex)
            {
                _response.IsExitoso = false;
                _response.Mensaje = ex.Message;
                _response.StatusCode = HttpStatusCode.BadRequest;
            }
            return Ok(_response); 
        }


    }
}
