using System;
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
            await context.SaveChangesAsync();
        }

        public async Task Excluir<T>(T usuario)
        {
            context.Remove(usuario);
            await context.SaveChangesAsync();
        }

        public async Task Salvar<T>(T usuario) 
        {
            context.Add(usuario);
            await context.SaveChangesAsync();
        }

        public async Task<T> FindById<T>(int id) where T : class
        {
            var entity = await context.Set<T>().FindAsync(id);
            context.Entry(entity).State = EntityState.Detached;
            return entity;
        }

      


    }
}