using System;
using System.Linq;
using System.Threading.Tasks;
using api.Dominio.Entidade;
using api.Dominio.Negocio.Servicos.Pessoa;
using api.Infra.Database;
using Microsoft.EntityFrameworkCore;

namespace api.InfraEstrutura.DataBase
{
    public class PessoaRepositorio<T> : IPessoaRepositorio<T> where T : class
    {

        private readonly EntityContext context;

        public PessoaRepositorio(EntityContext context){
            this.context = context;
        }

        
        public async Task Alterar(T pessoa)
        {
            context.Entry(pessoa).State = EntityState.Modified;
            await context.SaveChangesAsync();
        }

        public async Task<Operador> BuscarLoginSenhaOperador(string loginAcesso, string senhaAcesso)
        {
            return await context.Operador.Where(o => o.Documento == loginAcesso && o.Senha == senhaAcesso).FirstOrDefaultAsync();
        }

        public async Task<Usuario> BuscarLoginSenhaUsuario(string loginAcesso, string senhaAcesso)
        {
            
            return await context.Usuario.Where(u => u.Documento == loginAcesso && u.Senha == senhaAcesso).FirstOrDefaultAsync();
        }

        public async Task Excluir(T pessoa)
        {
            context.Set<T>().Remove(pessoa);
            await context.SaveChangesAsync();
        }

        public async Task Salvar(T pessoa)
        {
            context.Set<T>().Add(pessoa);
            await context.SaveChangesAsync();
        }
    }
}