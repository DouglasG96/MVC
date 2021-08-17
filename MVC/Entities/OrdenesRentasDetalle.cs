using System;
using System.Collections.Generic;

#nullable disable

namespace MVC.Entities
{
    public partial class OrdenesRentasDetalle
    {
        public int IdOrdenRentaDetalle { get; set; }
        public int? IdOrdenRenta { get; set; }
        public int? EstadoDetalle { get; set; }
        public int? IdPelicula { get; set; }
        public int? Cantidad { get; set; }

        public virtual OrdenesRentum IdOrdenRentaNavigation { get; set; }
        public virtual Pelicula IdPeliculaNavigation { get; set; }
    }
}
