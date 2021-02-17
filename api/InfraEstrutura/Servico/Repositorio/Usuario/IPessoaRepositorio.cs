using System;
using System.Threading.Tasks;
using api.Dominio.Entidade.Usuario;

namespace api.InfraEstrutura.Servico.Repositorio.Usuario
{
    public interface IPessoaRepositorio
    {
        Task<Pessoa> BuscarLoginSenha(string loginAcesso, string senhaAcesso);
    }
}
