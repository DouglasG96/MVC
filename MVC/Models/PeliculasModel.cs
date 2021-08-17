using MVC.Entities;
using MVC.Interfaces;
using MVC.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC.Models
{
    public class PeliculasModel : IPeliculas
    {
        private PeliculasContext _context;
        public PeliculasModel(PeliculasContext context)
        {
            _context = context;
        }

        public List<PeliculasViewModel> GetPeliculas()
        {
            try
            {
                return (from b in _context.Peliculas
                        select new PeliculasViewModel
                        {
                            IdPelicula = b.IdPelicula,
                            Titulo = b.Titulo,
                            FechaEstreno = b.FechaEstreno,
                            Clasificacion = b.Clasificacion,
                            Precio = b.Precio,
                            Imagen = b.Imagen
                        }).ToList();              
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;

            }
        }
    }
}
