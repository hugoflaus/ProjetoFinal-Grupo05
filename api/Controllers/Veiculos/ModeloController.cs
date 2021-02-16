using System.Threading.Tasks;
using api.Controllers.Login;
using api.Dominio.Entidade.Veiculo;
using api.Dominio.Negocio.Servicos;
using api.Infra.Database;
using api.InfraEstrutura.Servico.Repositorio;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace api.Controllers.Veiculos
{
    [ApiController]
    [Route("api/[controller]")]
    public class ModeloController : ControllerBase
    {
        private readonly EntityService<Modelo> _entityService;         
        private readonly ILogger<LoginController> _logger;

        public ModeloController(EntityContext context, ILogger<LoginController> logger)
        {
            _logger = logger;
            _entityService = new EntityService<Modelo>(new EntityRepositorio(context));            
        }


        [HttpGet]
        [Route("buscarTodos")]
        [AllowAnonymous]
        public async Task<ActionResult> BuscarTodos()
        {
            try
            {
                var veiculos = await _entityService.BuscarTodos();
                return StatusCode(200, veiculos);                                    
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
                var veiculo = await _entityService.BuscarPorId(id);
                return StatusCode(200, veiculo);                                    
            }
            catch (System.Exception er)
            {
                return StatusCode(401, new { er.Message });
            }
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult> Post([FromBody]Modelo modelo)
        {
            try
            {
                await _entityService.Salvar(modelo);
                return StatusCode(200);                                    
            }
            catch (System.Exception er)
            {
                return StatusCode(401, new { er.Message });
            }
        }

       /*  [HttpPut]
        [Route("/usuario/{id}")]
        [AllowAnonymous]
        public Task<ActionResult> Put(int id, [FromBody] Veiculo pessoaAlterar)
        {
            try
            {
                //await _entityService.Alterar(id, pessoaAlterar);
               // return StatusCode(200);
            }
            catch (System.Exception)
            {
                //return StatusCode(401, new { er.Message });
            }
        } */

        [HttpDelete]
        [Route("{id}")]
        [AllowAnonymous]
        public async Task<ActionResult> Remover(int id)
        {
            try
            {
                await _entityService.Excluir(id);
                return StatusCode(200);
            }
            catch (System.Exception er)
            {
                return StatusCode(401, new { er.Message });
            }
        }


    }
}