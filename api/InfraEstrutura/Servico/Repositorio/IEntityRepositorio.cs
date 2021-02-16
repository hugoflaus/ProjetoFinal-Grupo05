using System.Collections.Generic;
using System.Threading.Tasks;

namespace api.InfraEstrutura.Servico.Repositorio
{
    public interface IEntityRepositorio 
    {
        Task Alterar<T>(T usuario);
        Task Salvar<T>(T usuario);
        Task Excluir<T>(T usuario);   
        Task<List<T>> BuscarTodos<T>()  where T : class;
        Task<T> BuscarPorId<T>(int id) where T : class;       
    }
}