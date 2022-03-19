using Microsoft.AspNetCore.Mvc;
using Pagamento.Dominio.Interfaces.Services;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using System;
using Pagamento.Dominio.Exceptions;
using Pagamento.Dominio.DTO;
using System.Linq;

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
                var Url = await AuthSicoobService.GerarUrloAuth2(usuarioId, credenciasId);
                if(Url is not null)
                    return Ok(Url);

                return BadRequest(new ResponseRequestError("Não foi possivel gerar a Url", AuthSicoobService.GetAllNotes()));
            }
            catch(BaseException ex)
            {
                return BadRequest(new ResponseRequestError($"Não foi possivel gerar a Url TraceId:{ex.TraceId}", ex.Notes.ToList()));
            }
            catch (Exception ex)
            {                
                return BadRequest(new ResponseRequestError($"Não foi possivel gerar a Url \n {ex.Message}", AuthSicoobService.GetAllNotes()));
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
