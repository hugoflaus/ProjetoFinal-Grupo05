using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dominio.Entidade;

namespace api.InfraEstrutura.Servico.Repositorio
{
    public interface IPessoaRepositorio
    {
        Task<Pessoa> BuscarLoginSenha(string loginAcesso, string senhaAcesso);

    }
}
