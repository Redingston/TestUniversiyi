using DAL.Commands.Login;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    public class AuthController : ApiController
    {
        private readonly string _apiKey;

        public AuthController(IConfiguration config)
        {
            _apiKey = config.GetValue<string>("ApiKey");
        }

        /// <summary>       
        /// Login
        /// </summary>
        /// <param name="command"></param>                   // XML documentation
        /// <response code="200">Returns user token</response>
        /// <response code="401">Invalid username or password</response>
        /// <returns></returns>
        [ProducesResponseType(200)]
        [ProducesResponseType(401)]
        [ProducesResponseType(500)]
        [HttpPost]
        public async Task<ActionResult> Login([FromBody] LoginCommand command)
        {
            try
            {
                command.ApiKey = _apiKey;
                var result = await Mediator.Send(command);
                return Ok(result);
            }
            catch (ValidationException e)
            {
                return BadRequest(e.Message);
            }
            catch (Exception)
            {
                return BadRequest("Invalid password ");
            }
        }
    }
}
