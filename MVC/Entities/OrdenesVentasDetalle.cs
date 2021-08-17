using System;
using System.Collections.Generic;

#nullable disable

namespace MVC.Entities
{
    public partial class OrdenesVentasDetalle
    {
        public int IdOrdenVentaDetalle { get; set; }
        public int? IdOrdenVenta { get; set; }
        public int? EstadoDetalle { get; set; }
        public int? IdPelicula { get; set; }
        public int? Cantidad { get; set; }
        public decimal? MontoVenta { get; set; }

        public virtual OrdenesVenta IdOrdenVentaNavigation { get; set; }
        public virtual Pelicula IdPeliculaNavigation { get; set; }
    }
}
