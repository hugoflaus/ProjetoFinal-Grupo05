using api.Dominio.Autenticação;
using api.Dominio.Negocio.Builder;
using api.Dominio.Entidade;
using api.Dominio.ViewModel;
using System;
using System.Threading.Tasks;
using api.InfraEstrutura.Servico.Repositorio;

namespace api.Dominio.Negocio.Servicos.Usuarios
{
    public class PessoaService 
    {
        private IPessoaRepositorio  repositorio;
        private IEntityRepositorio  entityRepositorio;
        public PessoaService(IPessoaRepositorio repositorio, IEntityRepositorio entityRepositorio)
        {
            this.repositorio = repositorio;
            this.entityRepositorio = entityRepositorio;
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
            var pessoaBuilder = BuilderPessoa.ConverteEntidade<Pessoa>(pessoa);
            await entityRepositorio.Salvar<Pessoa>(pessoaBuilder);
        }

        public async Task Alterar(int id, Pessoa pessoa)
        {
            var pessoaAlteracao = await repositorio.FindById(id);

            if (pessoaAlteracao == null)
                throw new Exception("Usuario não encontrado.");
            
            //var pessoaBuilder = BuilderPessoa.ConverteEntidade<Pessoa>(pessoa);             
            await entityRepositorio.Alterar<Pessoa>(pessoa);  
        }
    }
}
