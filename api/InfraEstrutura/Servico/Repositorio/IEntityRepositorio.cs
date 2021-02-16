using System.Threading.Tasks;

namespace api.InfraEstrutura.Servico.Repositorio
{
    public interface IEntityRepositorio 
    {
        Task Alterar<T>(T usuario);
        Task Salvar<T>(T usuario);
        Task Excluir<T>(T usuario);          
    }
}