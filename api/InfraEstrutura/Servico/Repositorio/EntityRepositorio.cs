using System.Threading.Tasks;
using api.Infra.Database;
using Microsoft.EntityFrameworkCore;

namespace api.InfraEstrutura.Servico.Repositorio
{
    public class EntityRepositorio : IEntityRepositorio
    {
        private readonly EntityContext context;

        public EntityRepositorio(EntityContext context)
        {
            this.context = context;
        }
        public async Task Alterar<T>(T usuario)
        {
            context.Entry(usuario).State = EntityState.Modified;
            //context.Update(usuario);
            await context.SaveChangesAsync();
        }

        public Task Excluir<T>(T usuario)
        {
            throw new System.NotImplementedException();
        }

        public async Task Salvar<T>(T usuario) 
        {
            context.Add(usuario);
            await context.SaveChangesAsync();
        }


    }
}