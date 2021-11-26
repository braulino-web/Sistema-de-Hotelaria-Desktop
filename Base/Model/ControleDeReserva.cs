using System;
using System.Collections.Generic;

#nullable disable

namespace Base
{
    public partial class ControleDeReserva : IEntity
    {
        public int Id { get; set; }
        public DateTime? Entrada { get; set; }
        public DateTime? Saida { get; set; }
        public decimal? Valor { get; set; }
        public int? IdReserva { get; set; }

        public virtual Reserva IdReservaNavigation { get; set; }
    }
}
