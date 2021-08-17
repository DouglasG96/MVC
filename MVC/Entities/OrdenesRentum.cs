using System;
using System.Collections.Generic;

#nullable disable

namespace MVC.Entities
{
    public partial class OrdenesRentum
    {
        public int IdOrdenRenta { get; set; }
        public int? EstadoOrdenRenta { get; set; }
        public DateTime? FechaHoraOrdenRenta { get; set; }
        public DateTime? FechaVencimiento { get; set; }
        public int? IdUsuario { get; set; }

        public virtual Usuario IdUsuarioNavigation { get; set; }
    }
}
