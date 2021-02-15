

using System;
using System.Linq;
using System.Threading.Tasks;
using api.Dominio.Entidade;
using api.Infra.Database;
using Microsoft.EntityFrameworkCore;


namespace api.InfraEstrutura.Servico.Repositorio
{
    public class PessoaRepositorio : IPessoaRepositorio
    {

        private readonly EntityContext context;

        public PessoaRepositorio(EntityContext context){
            this.context = context;
        }

        public async Task<Pessoa> BuscarLoginSenha(string loginAcesso, string senhaAcesso)
        {
            return await context.Usuario.Where(u => u.Documento == loginAcesso && u.Senha == senhaAcesso).FirstOrDefaultAsync();
        }
    }
}

  