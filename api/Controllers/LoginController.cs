using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LoginController : ControllerBase
    {
        private readonly ILogger<LoginController> _logger;

        public LoginController(ILogger<LoginController> logger)
        {
            _logger = logger;
        }

        //[HttpGet]
        //[Route("/login")]
        //[AllowAnonymous]
        //public async Task<ActionResult> Login(PessoaLogin loginUsuario)
        //{
        //    return StatusCode(200, );
        //}
        

    }
}
