using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dominio.Entidade;

namespace api.Dominio.Negocio.Servicos.Pessoa
{
    public interface IPessoaRepositorio<T> 
    {
        Task Alterar(T pessoa);
        Task Salvar(T pessoa);
        Task Excluir(T pessoa);
        Task<Usuario> BuscarLoginSenha(string loginAcesso, string senhaAcesso);

    }
}
