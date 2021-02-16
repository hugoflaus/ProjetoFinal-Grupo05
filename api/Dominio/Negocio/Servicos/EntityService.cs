using System;
using System.Collections.Generic;
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

        public async Task Salvar(T entity){
            var entityBuilder = BuilderEntidade.ConverteEntidade<T>(entity);
            await entityRepositorio.Salvar<T>(entity);
        }

        public async Task Excluir(int id){
            var entity = await entityRepositorio.BuscarPorId<T>(id);
            if(entity == null){
                throw new Exception("Registro não encontrado");
            }

            await entityRepositorio.Excluir<T>(entity);
        }

        public async Task<T> BuscarPorId(int id){
            var entity = await entityRepositorio.BuscarPorId<T>(id);
            if(entity == null){
                throw new Exception("Registro não encontrado");
            }

            return entity;
        }
        
        public async Task<List<T>> BuscarTodos()
        {
            var pessoas = await entityRepositorio.BuscarTodos<T>();
            if (pessoas == null)
                throw new Exception("Usuario não encontrado.");
            
            return pessoas;   
        }
    }
}