using Application.Interfaces;
using Application.Models.Request;
using Microsoft.AspNetCore.Mvc;

namespace TPI_Viajes_Compartidos.Controllers
{
    [Route("api/authentication")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IConfiguration _config;
        private readonly ICustomAuthenticationService _customAuthenticationService;

        public AuthenticationController(IConfiguration config, ICustomAuthenticationService autenticacionService)
        {
            _config = config; //Hacemos la inyección para poder usar el appsettings.json
            _customAuthenticationService = autenticacionService;
        }


        [HttpPost("authenticate")] //Vamos a usar un POST ya que debemos enviar los datos para hacer el login
        public ActionResult<string> Autenticar(AuthenticationRequest authenticationRequest) //Enviamos como parámetro la clase que creamos arriba
        {
            string token = _customAuthenticationService.Autenticar(authenticationRequest)!; //Lo primero que hacemos es llamar a una función que valide los parámetros que enviamos.

            if (token == null) { 
                return Unauthorized();  //Tambien puedo devolver un 403: Forbiden
            }

            return Ok(token);
        }
    }
}
