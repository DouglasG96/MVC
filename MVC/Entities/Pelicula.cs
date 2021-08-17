using System;
using System.Collections.Generic;

#nullable disable

namespace MVC.Entities
{
    public partial class Pelicula
    {
        public Pelicula()
        {
            OrdenesVentasDetalles = new HashSet<OrdenesVentasDetalle>();
        }

        public int IdPelicula { get; set; }
        public int? IdTipoPelicula { get; set; }
        public int? EstadoPelicula { get; set; }
        public string Titulo { get; set; }
        public DateTime? FechaEstreno { get; set; }
        public string Clasificacion { get; set; }
        public decimal? Precio { get; set; }
        public byte[] Imagen { get; set; }

        public virtual TipoPelicula IdTipoPeliculaNavigation { get; set; }
        public virtual ICollection<OrdenesVentasDetalle> OrdenesVentasDetalles { get; set; }
    }
}
