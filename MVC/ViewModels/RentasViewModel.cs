using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC.ViewModels
{
    public class RentasViewModel
    {
        public int IdOrdenRenta { get; set; }
        public int? EstadoOrdenRenta { get; set; }
        public DateTime? FechaHoraOrdenRenta { get; set; }
        public DateTime? FechaVencimiento { get; set; }
        public int? IdUsuario { get; set; }

        public int IdOrdenRentaDetalle { get; set; }
        public int? EstadoDetalle { get; set; }
        public int? IdPelicula { get; set; }
        public int? Cantidad { get; set; }
    }
}
