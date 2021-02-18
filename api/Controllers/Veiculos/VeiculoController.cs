using System;
using System.Threading.Tasks;
using api.Controllers.Login;
using api.Dominio.Entidade.Veiculo;
using api.Dominio.Negocio.Builder;
using api.Dominio.Negocio.Servicos;
using api.Dominio.ViewModel.Veiculo;
using api.Infra.Database;
using api.InfraEstrutura.Servico.Repositorio;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace api.Controllers.Veiculos
{
    [ApiController]
    [Route("api/[controller]")]
    public class VeiculoController : ControllerBase
    {
        private readonly EntityService<Veiculo> _entityService;         
        private readonly ILogger<LoginController> _logger;

        public VeiculoController(EntityContext context, ILogger<LoginController> logger)
        {
            _logger = logger;
            _entityService = new EntityService<Veiculo>(new EntityRepositorio(context));            
        }


        [HttpGet]
        [Route("buscarTodos")]
        [AllowAnonymous]
        public async Task<ActionResult> BuscarTodos()
        {
            try
            {
                var veiculos = await _entityService.BuscarTodos(includes => includes.Categoria, 
                                                                includes => includes.Modelo,
                                                                includes => includes.Marca);
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
                var veiculo = await _entityService.BuscarPorId(veiculo => veiculo.Id == id, includes => includes.Categoria,
                                                                                            includes => includes.Modelo,
                                                                                            includes => includes.Marca);
                return StatusCode(200, veiculo);                                    
            }
            catch (System.Exception er)
            {
                return StatusCode(401, new { er.Message });
            }
        }

        [HttpGet]
        [Route("categotia/{categoria}")]
        [AllowAnonymous]
        public async Task<ActionResult> BuscarPorCategoria(int categoria)
        {
            try
            {
                var veiculos = await _entityService.Filtrar(veiculo => veiculo.IdCategoria == categoria, includes => includes.Categoria,
                                                                                            includes => includes.Modelo,
                                                                                            includes => includes.Marca);
                return StatusCode(200, veiculos);                                    
            }
            catch (System.Exception er)
            {
                return StatusCode(401, new { er.Message });
            }
        }


        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult> Post([FromBody]VeiculoVM veiculo)
        {
            try
            {
                var Builder = BuilderEntidade.ConverteEntidade<Veiculo>(veiculo);
                await _entityService.Salvar(Builder);
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
                var entity = await _entityService.BuscarPorId(veiculo => veiculo.Id == id);
                
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