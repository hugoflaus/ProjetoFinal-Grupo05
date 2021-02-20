using System;
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
                var modelo = await _entityService.BuscarTodos();
                return StatusCode(200, modelo);                                    
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
                var modelo = await _entityService.BuscarPorId(modelo => modelo.Id == id);
                return StatusCode(200, modelo);                                    
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
                return StatusCode(200, await _entityService.Salvar(modelo));                                    
            }
            catch (System.Exception er)
            {
                return StatusCode(401, new { er.Message });
            }
        }

        [HttpPut]
        [Route("{id}")]
        [AllowAnonymous]
        public async Task<ActionResult> Put(int id, [FromBody] Modelo modelo)
        {
            try
            {  
                var modeloAlteracao = await _entityService.BuscarPorId(modelo => modelo.Id == id);
                

                modelo.Id = modeloAlteracao.Id;
                var modeloBD = await _entityService.Alterar(modelo);
                return StatusCode(200, modeloBD);
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
                var entity = await _entityService.BuscarPorId(modelo => modelo.Id == id);

                if (entity == null)
                    throw new Exception("Registro não encontrado");

                await _entityService.Excluir(entity);
                return StatusCode(200);
            }
            catch (System.Exception er)
            {
                return StatusCode(401, new { er.Message });
            }
        }


    }
}