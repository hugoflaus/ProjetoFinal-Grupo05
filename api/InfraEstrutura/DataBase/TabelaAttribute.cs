using System;

namespace api.InfraEstrutura.DataBase
{
    public class TabelaAttribute : Attribute
    {
        public string Nome { get; set; }
    }
}