using Challenge.Valkimia.Application.Commands;
using Microsoft.AspNetCore.Mvc;

namespace Challenge.Valkimia.API.Controllers.v1
{
    [ApiVersion("1.0")]
    public class FacturasController : BaseApiController
    {
        /// <summary>
        /// Crear nueva factura.
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Create(CreateFacturaCommand command)
        {
            return Ok(await Mediator.Send(command));
        }
    }
}
