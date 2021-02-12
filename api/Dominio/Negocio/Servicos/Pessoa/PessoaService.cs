using api.Dominio.Entidade;
using api.Dominio.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Dominio.Negocio.Servicos.Usuarios
{
    public class PessoaService
    {
        private IPessoaRepositorio repositorio;
        public PessoaService(IPessoaRepositorio repositorio)
        {
            this.repositorio = repositorio;                
        }

        public async Task<PessoaLogin> LoginUsuario(Usuario pessoa)
        {
            var pessoaLogada = await repositorio.BuscarLoginSenhaUsuario(pessoa.Cpf, pessoa.Senha);

            if (pessoaLogada == null)
                throw new Exception("Usuario e Login invalidos");

            return new PessoaLogin()
            {
                Login = "Hugo",
                Senha = "123456"
            };
        }

    }
}
