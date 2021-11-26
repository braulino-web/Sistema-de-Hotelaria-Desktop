using System;
using System.Collections.Generic;

#nullable disable

namespace Base
{
    public partial class Reserva : IEntity
    {
        public Reserva()
        {
            TbControleDeReservas = new HashSet<ControleDeReserva>();
        }

        public int Id { get; set; }
        public int? IdQuarto { get; set; }
        public string Nome { get; set; }
        public DateTime? Entrada { get; set; }
        public DateTime? Saida { get; set; }
        public decimal? Valor { get; set; }
        public int? Idhospede { get; set; }

        public virtual Quarto IdQuartoNavigation { get; set; }
        public virtual Hospede IdhospedeNavigation { get; set; }
        public virtual ICollection<ControleDeReserva> TbControleDeReservas { get; set; }
    }
}
