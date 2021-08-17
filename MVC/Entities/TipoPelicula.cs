using System;
using System.Collections.Generic;

#nullable disable

namespace MVC.Entities
{
    public partial class TipoPelicula
    {
        public TipoPelicula()
        {
            Peliculas = new HashSet<Pelicula>();
        }

        public int IdTipoPelicula { get; set; }
        public string TipoPelicula1 { get; set; }
        public int? EstadoTipoPelicula { get; set; }

        public virtual ICollection<Pelicula> Peliculas { get; set; }
    }
}
