using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dominio.Entidade;

namespace api.Dominio.Negocio.Servicos.Pessoa
{
    public interface IPessoaRepositorio
    {
        Task Alterar(Usuario usuario);
        Task Salvar(Usuario usuario);
        Task Excluir(Usuario usuario);
        Task<Usuario> BuscarLoginSenha(string loginAcesso, string senhaAcesso);

    }
}
