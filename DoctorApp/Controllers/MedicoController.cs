using DoctorApp.DTOs;
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

    public class MedicoController : ControllerBase
    {
        private readonly IMedicoServicio _medicoidadServicio;
        private ApiResponse _response;

        public MedicoController(IMedicoServicio medicoidadServicio, ApiResponse response)
        {
            _medicoidadServicio = medicoidadServicio;
            _response = response;
        }


        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                _response.Resultado = await _medicoidadServicio.ObtenerTodos();
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




        [HttpPost]
        public async Task<IActionResult> Crear(MedicoDto modelDto)
        {
            try
            {
                await _medicoidadServicio.Agregar(modelDto);
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
        public async Task<IActionResult> Editar(MedicoDto modelDto)
        {
            try
            {
                await _medicoidadServicio.Actualizar(modelDto);
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
                await _medicoidadServicio.Remover(id);
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
