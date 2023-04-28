using Challenge.Valkimia.Application.Queries;
using Microsoft.AspNetCore.Mvc;

namespace Challenge.Valkimia.API.Controllers.v1
{
    [ApiVersion("1.0")]
    public class ClientesController : BaseApiController
    {
        /// <summary>
        /// Obtener todos los clientes.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await Mediator.Send(new GetAllClientesQuery()));
        }
    }
}
