using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC.ViewModels
{
    public class VentasViewModel
    {
        public int IdOrdenVenta { get; set; }
        public int? EstadoOrdenVenta { get; set; }
        public DateTime? FechaHoraOrdenVenta { get; set; }
        public decimal? TotalVenta { get; set; }
        public int? IdUsuario { get; set; }

        public int IdOrdenVentaDetalle { get; set; }
        public int? EstadoDetalle { get; set; }
        public int? IdPelicula { get; set; }
        public int? Cantidad { get; set; }
        public decimal? MontoVenta { get; set; }
    }
}
