using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace ApiPagamentos.Controllers
{
    public class AuthServiceController : BaseController
    {
        public AuthServiceController()
        {

        }
                
        // api/AuthService/return/{clienteid}/sicoob
        [HttpGet("return/{clienteId}/sicoob")]
        public async Task<IActionResult> RecebeCodigoSicoob([FromRoute] string cliente, [FromQuery][Required()] string code)
        {
            return Ok();
        }

        //api/AuthService/gerarurloAuth2/{clienteid}/sicoob?clienteId=
        [HttpGet("gerarurloAuth2/{clienteId}/sicoob")]
        public async Task<IActionResult> GerarUrlOAuth2Sicoob([FromQuery] string clienteId)
        {

            return Ok();
        }

        [HttpGet("refleshToken/{clienteId}/sicoob")]
        public async Task<IActionResult> RefleshTokenSicoob([FromQuery] string clienteId)
        {

            return Ok();
        }
    }
}
