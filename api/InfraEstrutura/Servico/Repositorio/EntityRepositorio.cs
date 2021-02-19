using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
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
        public async Task<T> Alterar<T>(T entity)
        {
            context.Entry(entity).State = EntityState.Modified;
            await context.SaveChangesAsync();
            return entity;
        }

        public async Task Excluir<T>(T entity)
        {
            context.Remove(entity);
            await context.SaveChangesAsync();
        }

        public async Task<T> Salvar<T>(T entity) 
        {
            context.Add(entity);
            await context.SaveChangesAsync();
            return entity;
        }

    
        public async Task<List<T>> Filtrar<T>(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includes) where T : class
        {
            var entity = context.Set<T>().Where(predicate);                                      

            foreach (Expression<Func<T, object>> i in includes)
            {
                entity = entity.Include(i);
            }

            return await entity.AsNoTracking<T>().ToListAsync();
        }       
        
        public async Task<T> Buscar<T>(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includes) where T : class
        {
            var entity = context.Set<T>().Where(predicate);                                      

            foreach (Expression<Func<T, object>> i in includes)
            {
                entity = entity.Include(i);
            }

            return await entity.AsNoTracking<T>().FirstOrDefaultAsync();
        }       
      

        public async Task<List<T>> BuscarTodos<T>(params Expression<Func<T, object>>[] includes) where T : class
        {
            //return await context.Set<T>().AsNoTracking<T>().ToListAsync();
            var entity = context.Set<T>().AsQueryable();
            foreach (Expression<Func<T, object>> incluir  in includes)       
            {
                entity = entity.Include(incluir);
            }
            return await entity.AsNoTracking<T>().ToListAsync();
        }

        public Task<T> Buscar<T>(params Expression<Func<T, object>>[] includes) where T : class
        {
            throw new NotImplementedException();
        }
    }
}