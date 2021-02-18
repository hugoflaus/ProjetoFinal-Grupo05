using System;
using System.Threading.Tasks;
using api.Controllers.Login;
using api.Dominio.Entidade.Agendamento;
using api.Dominio.Negocio.Builder;
using api.Dominio.ViewModel.Agendamento;
using api.Dominio.Negocio.Servicos;
using api.Infra.Database;
using api.InfraEstrutura.Servico.Repositorio;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using api.InfraEstrutura.Servico.Repositorio.Veiculo;
using api.Dominio.Negocio.Servicos.Agendamento;

namespace api.Controllers.Agendamentos
{
    [ApiController]
    [Route("api/[controller]")]
    public class ChecklistController : ControllerBase
    {

        private readonly ChecklistService _checklistService;         
        private readonly ILogger<LoginController> _logger;

        public ChecklistController(EntityContext context, ILogger<LoginController> logger)
        {
            _logger = logger;
            _checklistService = new ChecklistService(new ChecklistRepositorio(context), new EntityRepositorio(context));;            
        }

        [HttpPost]
        [AllowAnonymous]
        [Route("agendamento/{idAgendamento}")]
        public async Task<ActionResult> Post([FromBody]ChecklistVM checklistVM, int idAgendamento)
        {
            try
            {
                var Builder = BuilderEntidade.ConverteEntidade<Checklist>(checklistVM);
                await _checklistService.Salvar(Builder, idAgendamento);
                return StatusCode(200);                                    
            }
            catch (System.Exception er)
            {
                return StatusCode(401, new { er.Message });
            }
        }
       
    }
}