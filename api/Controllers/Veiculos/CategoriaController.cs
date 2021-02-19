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
    public class CategoriaController : ControllerBase
    {
        private readonly EntityService<Categoria> _entityService;         
        private readonly ILogger<LoginController> _logger;

        public CategoriaController(EntityContext context, ILogger<LoginController> logger)
        {
            _logger = logger;
            _entityService = new EntityService<Categoria>(new EntityRepositorio(context));            
        }


        [HttpGet]
        [Route("buscarTodos")]
        [AllowAnonymous]
        public async Task<ActionResult> BuscarTodos()
        {
            try
            {
                var categorias = await _entityService.BuscarTodos();
                return StatusCode(200, categorias);                                    
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
                var categoria = await _entityService.BuscarPorId(categoria => categoria.Id == id);
                return StatusCode(200, categoria);                                    
            }
            catch (System.Exception er)
            {
                return StatusCode(401, new { er.Message });
            }
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult> Post([FromBody]Categoria categoria)
        {
            try
            {
                return StatusCode(200, await _entityService.Salvar(categoria));                                    
            }
            catch (System.Exception er)
            {
                return StatusCode(401, new { er.Message });
            }
        }

        [HttpPut]
        [Route("/categoria/{id}")]
        [AllowAnonymous]
        public async Task<ActionResult> Put(int id, [FromBody] Categoria categoria)
        {
            try
            {  
                await _entityService.BuscarPorId(categoria => categoria.Id == id);
                var categoriaBD = await _entityService.Alterar(categoria);
                return StatusCode(200, categoriaBD);
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
                var entity = await _entityService.BuscarPorId(categoria => categoria.Id == id);

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