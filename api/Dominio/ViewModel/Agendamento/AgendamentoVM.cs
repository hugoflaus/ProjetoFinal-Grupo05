using System;

namespace api.Dominio.ViewModel.Agendamento
{
    public record AgendamentoVM
    {
        public int Id { get; set; }

        public DateTime DataAgendamento { get; set; }

        public DateTime DataColetaPrevista { get; set; }

        public DateTime DataColetaRealizada { get; set; }

        public DateTime DataEntregaPrevista { get; set; }

        public DateTime DataEntregaRealizada { get; set; }
        public Decimal ValorHora { get; set; }

        public Double HorasLocacao { get; set; }

        public Decimal SubTotal { get; set; }

        public Decimal CustosAdicionais { get; set; }

        public Decimal ValorTotal { get; set; }

        public bool RealizadaVistoria { get; set; }

        public int IdPessoa { get; set; }

        public int IdVeiculo { get; set; }   
        
        public int? IdChecklist { get; set; }
        
    }
}