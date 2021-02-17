using System.Threading.Tasks;
using api.Dominio.Negocio.Servicos.Usuarios;
using api.Dominio.ViewModel.Pessoa;
using api.Infra.Database;
using api.InfraEstrutura.Autenticação;
using api.InfraEstrutura.Servico.Repositorio;
using api.InfraEstrutura.Servico.Repositorio.Usuario;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace api.Controllers.Login
{
    [ApiController]
    [Route("api/[controller]")]
    public class LoginController : ControllerBase
    {

        private readonly PessoaService _pessoaUsuario;
        
        private readonly ILogger<LoginController> _logger;

        public LoginController(EntityContext context, ILogger<LoginController> logger)
        {
            _logger = logger;
            _pessoaUsuario = new PessoaService(new PessoaRepositorio(context), new EntityRepositorio(context));             
        }

        [HttpPost]
        [Route("/login")]
        [AllowAnonymous]
        public async Task<ActionResult> LoginUsuario([FromBody]PessoaLogin loginPessoa)
        {
            try
            {
                return StatusCode(200, await _pessoaUsuario.LoginPessoa(loginPessoa, new Token<PessoaLogin>()));                                    
            }
            catch (System.Exception er)
            {
                return StatusCode(401, new { er.Message });
            }
        }   
    }
}
