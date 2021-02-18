using api.Dominio.Entidade.Enums;

namespace api.Dominio.ViewModel.Veiculo
{
    public record VeiculoVM
    {
        public string Placa { get; set; }
        public string Ano { get; set; }
        public decimal ValorHora { get; set; }
        public string LimitePorMalas { get; set; }
        public int IdMarca { get; set; }
        public int IdModelo { get; set; }
        public int IdCategoria { get; set; }
        public Combustivel Combustivel { get; set; }
         public string KilomentroPorLitro { get; set; }

        public string VelocidadeMaxima { get; set; }

        public int Ocupantes { get; set; }

        public string Cambio { get; set; }

        public string Potencia { get; set; }

        public string url {get; set;}

        public string Descricao { get; set; }
    }
}