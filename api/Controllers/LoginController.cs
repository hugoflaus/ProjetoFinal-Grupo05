using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dominio.Entidade;
using api.Dominio.Negocio.Servicos.Usuarios;
using api.Dominio.ViewModel;
using api.Infra.Database;
using api.InfraEstrutura.Autenticação;
using api.InfraEstrutura.DataBase;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LoginController : ControllerBase
    {

        private readonly PessoaService<Usuario> _pessoaUsuario;
        private readonly PessoaService<Operador> _pessoaOperador;
        private readonly ILogger<LoginController> _logger;

        public LoginController(EntityContext context, ILogger<LoginController> logger)
        {
            _logger = logger;
            _pessoaUsuario = new PessoaService<Usuario>(new PessoaRepositorio<Usuario>(context));
            _pessoaOperador = new PessoaService<Operador>(new PessoaRepositorio<Operador>(context));
        }

        [HttpPost]
        [Route("/login/usuario")]
        [AllowAnonymous]
        public async Task<ActionResult> LoginUsuario([FromBody]PessoaLogin loginPessoa)
        {
            try
            {
                if (loginPessoa.Login.Length < 11)
                {
                    return StatusCode(200, await _pessoaOperador.LoginOperador(new Operador()
                    {
                        Matricula = loginPessoa.Login,
                        Senha = loginPessoa.Senha
                    }, new Token<Operador>()));
                }
                else
                {
                    return StatusCode(200, await _pessoaUsuario.LoginUsuario(new Usuario()
                    {
                        Cpf = loginPessoa.Login,
                        Senha = loginPessoa.Senha
                    }, new Token<Usuario>()));
                }
            }
            catch (System.Exception er)
            {

                return StatusCode(401, new { er.Message });
            }

        }
        /* [HttpGet]
        [Route("/login/operador")]
        [AllowAnonymous]
        public async Task<ActionResult> LoginOperador(PessoaLogin loginUsuario)
        {
            return StatusCode(200, );
        } */


    }
}
