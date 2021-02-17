using System;
using System.Threading.Tasks;
using api.Controllers.Login;
using api.Dominio.Entidade.Agendamento;
using api.Dominio.Negocio.Builder;
using api.Dominio.Negocio.Servicos;
using api.Dominio.ViewModel.Agendamento;
using api.Infra.Database;
using api.InfraEstrutura.Servico.Repositorio;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace api.Controllers.Agendamentos
{
    [ApiController]
    [Route("api/[controller]")]
    public class AgendamentoController : ControllerBase
    {
        private readonly EntityService<Agendamento> _entityService;         
        private readonly ILogger<LoginController> _logger;

        public AgendamentoController(EntityContext context, ILogger<LoginController> logger)
        {
            _logger = logger;
            _entityService = new EntityService<Agendamento>(new EntityRepositorio(context));            
        }


        [HttpGet]
        [Route("buscarTodos")]
        [AllowAnonymous]
        public async Task<ActionResult> BuscarTodos()
        {
            try
            {
                var agendamentos = await _entityService.BuscarTodos(includes => includes.Pessoa,
                                                                    includes => includes.Veiculo,
                                                                    includes => includes.Veiculo.Marca,
                                                                    includes => includes.Veiculo.Modelo,
                                                                    includes => includes.Veiculo.Categoria,
                                                                    includes => includes.Checklist);
                return StatusCode(200, agendamentos);                                    
            }
            catch (System.Exception er)
            {
                return StatusCode(401, new { er.Message });
            }
        }

        [HttpGet]
        [Route("buscarPorCPF/{cpf}")]
        [AllowAnonymous]
        public async Task<ActionResult> BuscarPorCPF(string cpf)
        {
            try
            {
                var veiculos = await _entityService.BuscarPorPessoa(agendamento => agendamento.Pessoa.Documento == cpf,
                                                                    includes => includes.Pessoa,
                                                                    includes => includes.Veiculo,
                                                                    includes => includes.Veiculo.Marca,
                                                                    includes => includes.Veiculo.Modelo,
                                                                    includes => includes.Veiculo.Categoria,
                                                                    includes => includes.Checklist);
                return StatusCode(200, veiculos);                                    
            }
            catch (System.Exception er)
            {
                return StatusCode(401, new { er.Message });
            }
        }


        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult> Post([FromBody]AgendamentoVM agendamento)
        {
            try
            {
                var Builder = BuilderEntidade.ConverteEntidade<Agendamento>(agendamento);
                await _entityService.Salvar(Builder);
                return StatusCode(200);                                    
            }
            catch (System.Exception er)
            {
                return StatusCode(401, new { er.Message });
            }
        }
    }
}