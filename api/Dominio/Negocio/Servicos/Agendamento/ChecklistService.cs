using System.Threading.Tasks;
using api.Dominio.Entidade.Agendamento;
using api.InfraEstrutura.Servico.Repositorio;
using api.InfraEstrutura.Servico.Repositorio.Veiculo;

namespace api.Dominio.Negocio.Servicos.Agendamento
{
     public class ChecklistService 
    {
        private IChecklistRepositorio  checklistRepositorio;
        private IEntityRepositorio  entityRepositorio;
        public ChecklistService(IChecklistRepositorio checklistRepositorio, IEntityRepositorio entityRepositorio)
        {
            this.checklistRepositorio = checklistRepositorio;
            this.entityRepositorio = entityRepositorio;
        }

        public async Task Salvar(Checklist checklist, int idAgendamento)
        {
            var entidade = await checklistRepositorio.Salvar<Checklist>(checklist);
            var agendamento = await entityRepositorio.Buscar<Dominio.Entidade.Agendamento.Agendamento>(a => a.Id == idAgendamento);
            if(agendamento == null)
            {
                throw new System.Exception("Não existe agendamento para este checklist");
            }
            
            agendamento.IdChecklist = entidade.Id;
            await entityRepositorio.Alterar<Dominio.Entidade.Agendamento.Agendamento>(agendamento);
        }

    }
}