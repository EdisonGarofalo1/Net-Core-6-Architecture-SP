using CARRITO.Appication.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CARRITO.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriaController : ControllerBase
    {
        private readonly ICategoriaService _service;

        public CategoriaController(ICategoriaService service)
        {
            _service = service;

        }

        [HttpGet("listar")]
        public async Task<JsonResult> getCategoria()
        {

            return new JsonResult(await _service.getCategoria());
        }
    }
}
