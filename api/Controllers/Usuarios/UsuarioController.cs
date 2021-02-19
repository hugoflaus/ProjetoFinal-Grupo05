using System.Threading.Tasks;
using api.Controllers.Login;
using api.Dominio.Negocio.Servicos.Usuarios;
using api.Dominio.ViewModel.Pessoa;
using api.Infra.Database;
using api.InfraEstrutura.Servico.Repositorio;
using api.InfraEstrutura.Servico.Repositorio.Usuario;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace api.Controllers.Usuarios
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuarioController : ControllerBase
    {

        private readonly PessoaService _pessoaUsuario;         
        private readonly ILogger<LoginController> _logger;

        public UsuarioController(EntityContext context, ILogger<LoginController> logger)
        {
            _logger = logger;
            _pessoaUsuario = new PessoaService(new PessoaRepositorio(context), new EntityRepositorio(context));            
        }


        [HttpGet]
        [Route("buscarTodos")]
        [AllowAnonymous]
        public async Task<ActionResult> BuscarTodos()
        {
            try
            {
                var pessoas = await _pessoaUsuario.BuscarTodos();
                return StatusCode(200, pessoas);                                    
            }
            catch (System.Exception er)
            {
                return StatusCode(401, new { er.Message });
            }
        }



        [HttpGet]
        [Route("{id}")]
        [AllowAnonymous]
        public async Task<ActionResult> BuscarPorId(int id)
        {
            try
            {
                var pessoa = await _pessoaUsuario.BuscarPorId(id);
                return StatusCode(200, pessoa);                                    
            }
            catch (System.Exception er)
            {
                return StatusCode(401, new { er.Message });
            }
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult> Post([FromBody]PessoaSalvar pessoaSalvar)
        {
            try
            {
                await _pessoaUsuario.VerificaUsuarioCadastrado(pessoaSalvar.Documento);
                return StatusCode(200, await _pessoaUsuario.Salvar(pessoaSalvar));                                    
            }
            catch (System.Exception er)
            {
                return StatusCode(401, new { er.Message });
            }
        }

        [HttpPut]
        [Route("{id}")]
        [AllowAnonymous]
        public async Task<ActionResult> Put(int id, [FromBody] PessoaAlterar pessoaAlterar)
        {
            try
            {
                return StatusCode(200, await _pessoaUsuario.Alterar(id, pessoaAlterar));
            }
            catch (System.Exception er)
            {
                return StatusCode(401, new { er.Message });
            }
        }

        [HttpDelete]
        [Route("{id}")]
        [AllowAnonymous]
        public async Task<ActionResult> Remover(int id)
        {
            try
            {
                await _pessoaUsuario.Remover(id);
                return StatusCode(200);
            }
            catch (System.Exception er)
            {
                return StatusCode(401, new { er.Message });
            }
        }
    }
}
