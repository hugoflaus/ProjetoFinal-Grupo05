using System;

namespace api.Dominio.ViewModel.Agendamento
{
    public record ChecklistVM
    {
        public int Id { get; set; }

        public bool CarroLimpo { get; set; }

        public bool TanqueCheio { get; set; }

        public int TanqueLitroPendent { get; set; }

        public bool Amassados { get; set; }

        public bool Arranhoes { get; set; }

    }
}