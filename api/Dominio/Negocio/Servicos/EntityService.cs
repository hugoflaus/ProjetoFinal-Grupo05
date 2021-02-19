using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using api.Dominio.Negocio.Builder;
using api.InfraEstrutura.Servico.Repositorio;

namespace api.Dominio.Negocio.Servicos
{
    public class EntityService<T> where T : class
    {
        private IEntityRepositorio entityRepositorio;

        public EntityService(IEntityRepositorio entityRepositorio){
            this.entityRepositorio = entityRepositorio;
        }

        public async Task<T> Salvar(T entity){ 
            
            var entidateBD = await entityRepositorio.Salvar(entity);
            return entidateBD;
        }

        public async Task<T> Alterar(T entity){ 
           
            var entidateBD = await entityRepositorio.Alterar(entity);
            return entidateBD;
        }

        public async Task Excluir(T entity)
        {         

            await entityRepositorio.Excluir<T>(entity);
        }

        public async Task<T> BuscarPorId(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includes)
        {
            var entity = await entityRepositorio.Buscar<T>(predicate, includes);
            if(entity == null){
                throw new Exception("Registro não encontrado");
            }

            return entity;
        }

        public async Task<List<T>> BuscarPorPessoa(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includes)
        {
            var entity = await entityRepositorio.Filtrar<T>(predicate, includes);
            if(entity == null){
                throw new Exception("Registro não encontrado");
            }

            return entity;
        }
        
        public async Task<List<T>> BuscarTodos(params Expression<Func<T, object>>[] includes)
        {
            var entity = await entityRepositorio.BuscarTodos<T>(includes);
            if (entity == null)
                throw new Exception("Registro não encontrado.");
            
            return entity;   
        }
        public async Task<List<T>> Filtrar(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includes)
        {
            var entity = await entityRepositorio.Filtrar<T>(predicate, includes);
            if(entity == null){
                throw new Exception("Registro não encontrado");
            }

            return entity;
        }
    }
}