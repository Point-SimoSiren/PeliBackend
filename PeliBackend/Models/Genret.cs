using System;
using System.Collections.Generic;

namespace PeliBackend.Models
{
    public partial class Genret
    {
        public Genret()
        {
            Pelits = new HashSet<Pelit>();
        }

        public int GenreId { get; set; }
        public string Genre { get; set; } = null!;
        public string Kuvaus { get; set; } = null!;

        public virtual ICollection<Pelit> Pelits { get; set; }
    }
}
