using Microsoft.AspNetCore.Mvc;
using Pagamento.Dominio.Interfaces.Services;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using System;
using Pagamento.Dominio.Exceptions;

namespace ApiPagamentos.Controllers
{
    public class AuthServiceController : BaseController
    {
        public IAuthSicoobService AuthSicoobService { get; }

        public AuthServiceController(IAuthSicoobService authSicoobService)
        {
            AuthSicoobService = authSicoobService;
        }

        // api/AuthService/return/{clienteid}/sicoob
        [HttpGet("return/{credenciasId}/sicoob")]
        public async Task<IActionResult> RecebeCodigoSicoob([FromRoute][Required()] int credenciasId, [FromQuery][Required()] string code)
        {
            try
            {
                return Ok();

            }
            catch (Exception)
            {
                return BadRequest();                
            }
        }

        //api/AuthService/gerarurloAuth2/{usuarioId}/sicoob?credenciasId=
        [HttpGet("gerarurloAuth2/{usuarioId}/sicoob")]
        public async Task<IActionResult> GerarUrlOAuth2Sicoob([FromRoute][Required()] int usuarioId, [FromQuery][Required()] int credenciasId)
        {
            try
            {
                return Ok(AuthSicoobService.GerarUrloAuth2(usuarioId, credenciasId));
            }
            catch(BaseException baseEx)
            {
                return 
            }
            catch (Exception ex)
            {
                return BadRequest($"Não foi possivel gerar a Url de Autorização traceId:{"ID"}");
            }
        }

        [HttpGet("refleshToken/{credenciasId}/sicoob")]
        public async Task<IActionResult> RefleshTokenSicoob([FromRoute][Required()] string credenciasId)
        {
            try
            {
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}
