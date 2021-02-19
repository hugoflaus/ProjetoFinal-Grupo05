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
        private readonly EntityService<Checklist> _entityService;
        private readonly ChecklistService _checklistService;         
        private readonly ILogger<LoginController> _logger;

        public ChecklistController(EntityContext context, ILogger<LoginController> logger)
        {
            _logger = logger;
            _checklistService = new ChecklistService(new ChecklistRepositorio(context), new EntityRepositorio(context));
            _entityService = new EntityService<Checklist>(new EntityRepositorio(context));


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

        [HttpGet]
        [AllowAnonymous]
        [Route("{idCheckList}")]
        public async Task<ActionResult> BuscarPorId(int idCheckList)
        {
          try
          {
            var checkList = await _entityService.BuscarPorId(checkList => checkList.Id == idCheckList);
            return StatusCode(200, checkList);
          }
          catch (System.Exception er)
          {
            return StatusCode(401, new { er.Message });
          }
        }

        [HttpPut]
        [Route("{id}")]
        [AllowAnonymous]
        public async Task<ActionResult> Put(int id, [FromBody] ChecklistVM checklist)
        {
          try
          {
            var Builder = BuilderEntidade.ConverteEntidade<Checklist>(checklist);
            var registro = await _entityService.BuscarPorId(checklist => checklist.Id == id);
            
            if (registro == null) 
              throw new Exception("O identificador não foi encontrado");

            Builder.Id = id;
            var checklistBD = await _entityService.Alterar(Builder);
            return StatusCode(200, checklistBD);

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
            var entity = await _entityService.BuscarPorId(checklist => checklist.Id == id);

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