using System;
using System.Collections.Generic;

#nullable disable

namespace MVC.Entities
{
    public partial class OrdenesVenta
    {
        public OrdenesVenta()
        {
            OrdenesVentasDetalles = new HashSet<OrdenesVentasDetalle>();
        }

        public int IdOrdenVenta { get; set; }
        public int? EstadoOrdenVenta { get; set; }
        public DateTime? FechaHoraOrdenVenta { get; set; }
        public decimal? TotalVenta { get; set; }
        public int? IdUsuario { get; set; }

        public virtual Usuario IdUsuarioNavigation { get; set; }
        public virtual ICollection<OrdenesVentasDetalle> OrdenesVentasDetalles { get; set; }
    }
}
