using api.Dominio.Entidade.Usuario;

namespace api.Dominio.Autenticação
{
    public interface IToken
    {
        string GerarToken(Pessoa pessoa);
    }
}