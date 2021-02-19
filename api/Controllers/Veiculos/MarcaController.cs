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
    public class MarcaController : ControllerBase
    {
        private readonly EntityService<Marca> _entityService;         
        private readonly ILogger<LoginController> _logger;

        public MarcaController(EntityContext context, ILogger<LoginController> logger)
        {
            _logger = logger;
            _entityService = new EntityService<Marca>(new EntityRepositorio(context));            
        }


        [HttpGet]
        [Route("buscarTodos")]
        [AllowAnonymous]
        public async Task<ActionResult> BuscarTodos()
        {
            try
            {
                var marcas = await _entityService.BuscarTodos();
                return StatusCode(200, marcas);                                    
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
                var marca = await _entityService.BuscarPorId(marca => marca.Id == id);
                return StatusCode(200, marca);                                    
            }
            catch (System.Exception er)
            {
                return StatusCode(401, new { er.Message });
            }
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult> Post([FromBody]Marca marca)
        {
            try
            {
               
                return StatusCode(200,  await _entityService.Salvar(marca));                                    
            }
            catch (System.Exception er)
            {
                return StatusCode(401, new { er.Message });
            }
        }

        [HttpPut]
        [Route("/marca/{id}")]
        [AllowAnonymous]
        public async Task<ActionResult> Put(int id, [FromBody] Marca marca)
        {
            try
            {  
                var marcaAlteracao = await _entityService.BuscarPorId(marca => marca.Id == id);

                if(marcaAlteracao == null)
                  throw new Exception("O identificador não foi encontrado");

                marca.Id = marcaAlteracao.Id;
                var marcaBD = await _entityService.Alterar(marca);
                return StatusCode(200, marcaBD);
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
                var entity = await _entityService.BuscarPorId(marca => marca.Id == id);

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