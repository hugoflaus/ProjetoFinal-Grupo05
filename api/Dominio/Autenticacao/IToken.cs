using api.Dominio.Entidade;

namespace api.Dominio.Autenticação
{
    public interface IToken
    {
        string GerarToken(Usuario pessoa);
        string GerarToken(Operador pessoa);
    }
}