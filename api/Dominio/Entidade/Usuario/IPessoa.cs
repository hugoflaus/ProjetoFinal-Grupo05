using api.Dominio.Entidade.Enums;

namespace api.Dominio.Entidade.Usuario
{
    public interface IPessoa
    {
        int Id {get; set;}
        string Nome {get; set;}
        string Senha {get; set;}
        string Documento {get; set; }
        int Tipo {get; set; }
        PersonRole Regra {get;}
    }
}