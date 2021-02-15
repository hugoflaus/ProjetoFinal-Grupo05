using api.Dominio.Entidade;

namespace api.Dominio.Autenticação
{
    public interface IToken
    {
        string GerarToken(Pessoa pessoa);
    }
}