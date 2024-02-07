using DoctorApp.Context;
using DoctorApp.Controllers.Errores;
using DoctorApp.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DoctorApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ErrorTestController : ControllerBase
    { 
        private readonly ContextDb _db;

        public ErrorTestController(ContextDb db)
        {
            _db = db;
        }

        //[Authorize]
        [HttpGet("auth")]
        public ActionResult<string> GetNotAuthorize()
        {
            return "No Autorizado";
        }

        //[Authorize]
        [HttpGet("not-found")]
        public ActionResult<UsuarioModels> GetNotFound()
        {
            var objeto = _db.Usuarios.Find(-1);
            if (objeto == null) return NotFound(new ApiErrorResponse(404));
            return objeto;
        }




        //[Authorize]
        [HttpGet("server-found")]
        public ActionResult<string> GetServerError()
        {
            var objeto = _db.Usuarios.Find(-1);
            var objetoString = objeto.ToString();
            return objetoString;
        }



        //[Authorize]
        [HttpGet("bad-request")]
        public ActionResult<string> GetBadRequest()
        {
            return BadRequest(new ApiErrorResponse(400));
        }
    }
}
