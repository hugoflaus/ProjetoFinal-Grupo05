using api.Dominio.Autenticação;
using api.Dominio.Entidade;
using api.Dominio.Negocio.Servicos.Pessoa;
using api.Dominio.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Dominio.Negocio.Servicos.Usuarios
{
    public class PessoaService<T> 
    {
        private IPessoaRepositorio<T> repositorio;
        public PessoaService(IPessoaRepositorio<T> repositorio)
        {
            this.repositorio = repositorio;                
        }

        public async Task<PessoaJwt> LoginUsuario(Usuario pessoa, IToken token)
        {
             Console.WriteLine("Chegou service"+pessoa.Cpf);
            var pessoaLogada = await repositorio.BuscarLoginSenhaUsuario(pessoa.Cpf, pessoa.Senha);

            if (pessoaLogada == null)
                throw new Exception("Usuario e Login invalidos");

            return new PessoaJwt()
            {
               Id = pessoaLogada.Id,
               Name = pessoaLogada.Nome,
               Token = token.GerarToken(pessoaLogada)
            };
        }
        public async Task<PessoaJwt> LoginOperador(Operador pessoa, IToken token)
        {
            var pessoaLogada = await repositorio.BuscarLoginSenhaOperador(pessoa.Matricula, pessoa.Senha);

            if (pessoaLogada == null)
                throw new Exception("Usuario e Login invalidos");

            return new PessoaJwt()
            {
               Id = pessoaLogada.Id,
               Name = pessoaLogada.Nome,
               Token = token.GerarToken(pessoaLogada)
            };
        }

    }
}
