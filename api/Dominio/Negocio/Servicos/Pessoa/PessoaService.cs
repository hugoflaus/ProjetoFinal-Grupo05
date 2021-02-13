using api.Dominio.Autenticação;
using api.Dominio.Entidade;
using api.Dominio.Negocio.Builder;
using api.Dominio.Negocio.Servicos.Pessoa;
using api.Dominio.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Dominio.Negocio.Servicos.Usuarios
{
    public class PessoaService 
    {
        private IPessoaRepositorio  repositorio;
        public PessoaService(IPessoaRepositorio repositorio)
        {
            this.repositorio = repositorio;
        }

        public async Task<PessoaJwt> LoginPessoa(PessoaLogin pessoa, IToken token)
        {

            if(pessoa.Login.Length >=11)
            {
                if(!ValidaCPF.ValidarCPF(pessoa.Login)) 
                    throw new Exception("CPF inválido !");
            }

            var pessoaLogada = await repositorio.BuscarLoginSenha(pessoa.Login, pessoa.Senha);

            if (pessoaLogada == null)
                throw new Exception("Usuario e Login invalidos");

            return new PessoaJwt()
            {
                Id = pessoaLogada.Id,
                Name = pessoaLogada.Nome,
                Token = token.GerarToken(pessoaLogada)
            };
        }

        public async Task Salvar(PessoaSalvar pessoa)
        {
            var pessoaBuilder = BuilderPessoa.ConverteEntidade<Usuario>(pessoa);
            await repositorio.Salvar(pessoaBuilder);
        }
    }
}
