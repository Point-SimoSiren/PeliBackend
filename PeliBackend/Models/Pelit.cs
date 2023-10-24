using System;
using System.Collections.Generic;

namespace PeliBackend.Models
{
    public partial class Pelit
    {
        public int PeliId { get; set; }
        public string Nimi { get; set; } = null!;
        public string Tekijä { get; set; } = null!;
        public int Julkaisuvuosi { get; set; }
        public int GenreId { get; set; }

        public virtual Genret Genre { get; set; } = null!;
    }
}
