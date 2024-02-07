using DoctorApp.Controllers.Errores;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DoctorApp.Controllers
{
    [Route("api/[controller]/error/{codigo}")]
    [ApiExplorerSettings(IgnoreApi = true)]
    public class ErrorController : ControllerBase
    {
        public IActionResult Error(int codigo)
        {
            return new ObjectResult(new ApiErrorResponse(codigo));
        }
    }
}
