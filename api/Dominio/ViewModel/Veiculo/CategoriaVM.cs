﻿namespace api.Dominio.ViewModel.Veiculo
{
    public record CategoriaVM
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string url { get; set; }
        public string Descricao { get; set; }
  }
}