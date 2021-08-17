using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC.ViewModels
{
    public class PeliculasViewModel
    {
        public int IdPelicula { get; set; }
        public int? IdTipoPelicula { get; set; }
        public int? EstadoPelicula { get; set; }
        public string Titulo { get; set; }
        public DateTime? FechaEstreno { get; set; }
        public string Clasificacion { get; set; }
        public decimal? Precio { get; set; }
        public byte[] Imagen { get; set; }
    }
}
