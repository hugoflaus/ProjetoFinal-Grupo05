using System;
using System.Threading.Tasks;
using api.Dominio.Entidade.Usuario;

namespace api.InfraEstrutura.Servico.Repositorio.Veiculo
{
    public interface IChecklistRepositorio
    {
        Task<T> Salvar<T>(T entityRepositorio);
    }
}
