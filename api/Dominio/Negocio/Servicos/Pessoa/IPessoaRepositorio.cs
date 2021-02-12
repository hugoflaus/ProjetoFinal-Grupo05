using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dominio.Entidade;

namespace api.Dominio.Negocio.Servicos.Usuarios
{
    public interface IPessoaRepositorio
    {
        Task Alterar<T>(T pessoa);
        Task Salvar<T>(T pessoa);
        Task Excluir<T>(T pessoa);
        Task<Usuario> BuscarLoginSenhaUsuario(string loginAcesso, string senhaAcesso);
        Task<Operador> BuscarLoginSenhaOperador(string loginAcesso, string senhaAcesso);

    }
}
