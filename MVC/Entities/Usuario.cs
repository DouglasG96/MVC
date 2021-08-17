using System;
using System.Collections.Generic;

#nullable disable

namespace MVC.Entities
{
    public partial class Usuario
    {
        public Usuario()
        {
            OrdenesRenta = new HashSet<OrdenesRentum>();
            OrdenesVenta = new HashSet<OrdenesVenta>();
        }

        public int IdUsuario { get; set; }
        public string NombreCompleto { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string Dui { get; set; }
        public string TelefonoContacto { get; set; }
        public string CorreoElectronico { get; set; }
        public string Contrasena { get; set; }

        public virtual ICollection<OrdenesRentum> OrdenesRenta { get; set; }
        public virtual ICollection<OrdenesVenta> OrdenesVenta { get; set; }
    }
}
