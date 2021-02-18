

using System;
using System.Linq;
using System.Threading.Tasks;
using api.Dominio.Entidade.Usuario;
using api.Infra.Database;
using Microsoft.EntityFrameworkCore;


namespace api.InfraEstrutura.Servico.Repositorio.Veiculo
{
    public class ChecklistRepositorio : IChecklistRepositorio
    {
        private readonly EntityContext context;

        public ChecklistRepositorio(EntityContext context){
            this.context = context;
        }

        public async Task<T> Salvar<T>(T checklist)
        {
            context.Add(checklist);
            await context.SaveChangesAsync();

            return checklist;
        }
    }
}

  