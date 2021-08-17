using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MVC.ViewModels
{
    public class UsuariosViewModel
    {
        public int IdUsuario { get; set; }
        public string NombreCompleto { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string Dui { get; set; }
        public string TelefonoContacto { get; set; }
        public string CorreoElectronico { get; set; }
        public string Contrasena { get; set; }

    }
}
