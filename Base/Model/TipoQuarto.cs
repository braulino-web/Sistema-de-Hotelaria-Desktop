using System;
using System.Collections.Generic;

#nullable disable

namespace Base
{
    public partial class TipoQuarto : IEntity
    {
        public TipoQuarto()
        {
            TbQuartos = new HashSet<Quarto>();
        }

        public int Id { get; set; }
        public string Nome { get; set; }
        public string Img1 { get; set; }
        public string Img2 { get; set; }
        public string Img3 { get; set; }

        public virtual ICollection<Quarto> TbQuartos { get; set; }
    }
}
