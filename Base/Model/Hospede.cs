using System;
using System.Collections.Generic;

#nullable disable

namespace Base
{
    public partial class Pessoa:IEntity
    {
        public Pessoa()
        {
            TbReservas = new HashSet<Reserva>();
        }

        public int Id { get; set; }
        public string Nome { get; set; }
        public string Usuario { get; set; }
        public string Senha { get; set; }
        public string NmrHospede { get; set; }
        public decimal? NmrCpf { get; set; }
        public decimal? NmrRg { get; set; }
        public string NrTelefone { get; set; }
        public string NrCelular { get; set; }
        public DateTime? DtNasc { get; set; }

        public virtual ICollection<Reserva> TbReservas { get; set; }
    }
}
