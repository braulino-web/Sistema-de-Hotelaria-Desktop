using System;
using System.Collections.Generic;

#nullable disable

namespace Base
{
    public partial class Quarto : IEntity
    {
        public Quarto()
        {
            TbReservas = new HashSet<Reserva>();
        }

        public int Id { get; set; }
        public string Nome { get; set; }
        public int? Tipo { get; set; }
        public bool Dispobilidade { get; set; }
        public decimal? Valor { get; set; }

        public virtual TipoQuarto TipoNavigation { get; set; }
        public virtual ICollection<Reserva> TbReservas { get; set; }
    }
}
