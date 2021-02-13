using System;
using System.Linq;
using System.Threading.Tasks;
using api.Dominio.Entidade;
using api.Dominio.Negocio.Servicos.Pessoa;
using api.Infra.Database;
using Microsoft.EntityFrameworkCore;

namespace api.InfraEstrutura.DataBase
{
    public class PessoaRepositorio : IPessoaRepositorio
    {

        private readonly EntityContext context;

        public PessoaRepositorio(EntityContext context){
            this.context = context;
        }

        
        public async Task Alterar(Usuario pessoa)
        {
            context.Entry(pessoa).State = EntityState.Modified;
            await context.SaveChangesAsync();
        }

        public async Task<Usuario> BuscarLoginSenha(string loginAcesso, string senhaAcesso)
        {
            Console.WriteLine("Chegou aqui");
            return await context.Usuario.Where(u => u.Documento == loginAcesso && u.Senha == senhaAcesso).FirstOrDefaultAsync();
        }

        public async Task Excluir(Usuario pessoa)
        {
            context.Usuario.Remove(pessoa);
            await context.SaveChangesAsync();
        }

        public async Task Salvar(Usuario pessoa)
        {
            context.Usuario.Add(pessoa);
            await context.SaveChangesAsync();
        }
    }
}