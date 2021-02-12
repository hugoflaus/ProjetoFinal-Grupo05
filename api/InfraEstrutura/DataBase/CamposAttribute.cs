using System;

namespace api.InfraEstrutura.DataBase
{
    public class CamposAttribute : Attribute
    {
        public string NomeColuna { get; set; }
    }
}