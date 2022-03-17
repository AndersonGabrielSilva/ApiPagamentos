using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace ApiPagamentos.Controllers
{
    public class AuthReturnController : BaseController
    {
        public AuthReturnController()
        {

        }

        [HttpGet("{clienteId}/Sicoob")]
        public IActionResult RecebeCodigoSicoob([FromRoute] string cliente, [FromQuery][Required()] string code)
        {
            return Ok();
        }
    }
}
