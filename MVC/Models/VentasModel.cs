using MVC.Entities;
using MVC.Interfaces;
using MVC.ViewModels;
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace MVC.Models
{
    public class VentasModel : IVentas
    {
        private PeliculasContext _context;
        public VentasModel(PeliculasContext context)
        {
            _context = context;
        }

        public List<VentasViewModel> GetVentas()
        {
            try
            {
                return (from b in _context.OrdenesVentas
                        select new VentasViewModel
                        {
                            IdOrdenVenta = b.IdOrdenVenta,
                            FechaHoraOrdenVenta = b.FechaHoraOrdenVenta,
                            TotalVenta = b.TotalVenta,
                            IdUsuario = b.IdUsuario,
                            EstadoOrdenVenta = b.EstadoOrdenVenta
                        }).ToList();              
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;

            }
        }

        public VentasViewModel GetVentaById(int id)
        {
            try
            {
                VentasViewModel model = new VentasViewModel();
                var ousuario = _context.OrdenesVentas.Find(id);//obtenemos registro por medio de id
                model.IdOrdenVenta= ousuario.IdOrdenVenta;
                model.FechaHoraOrdenVenta = ousuario.FechaHoraOrdenVenta;
                model.TotalVenta = ousuario.TotalVenta;
                model.IdUsuario = ousuario.IdUsuario;
                model.EstadoOrdenVenta = ousuario.EstadoOrdenVenta;
                return model;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return new VentasViewModel();
            }
        }

        public OrdenesVenta CreateVentas(VentasViewModel venta)
        {
            var ousuario = new OrdenesVenta();
            try
            {                 
                ousuario.IdOrdenVenta = venta.IdOrdenVenta;
                ousuario.FechaHoraOrdenVenta = venta.FechaHoraOrdenVenta;
                ousuario.TotalVenta = venta.TotalVenta;
                ousuario.IdUsuario = venta.IdUsuario;
                ousuario.EstadoOrdenVenta = venta.EstadoOrdenVenta;

                _context.OrdenesVentas.Add(ousuario);
                _context.SaveChanges();
                return ousuario;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            return ousuario;
        }

        public OrdenesVenta UpdateVentas(VentasViewModel ventas)
        {
            try
            {
                var ousuario = _context.OrdenesVentas.Find(ventas.IdOrdenVenta);//obtenemos registro por medio de id
                ousuario.IdOrdenVenta = ventas.IdOrdenVenta;
                ousuario.FechaHoraOrdenVenta = ventas.FechaHoraOrdenVenta;
                ousuario.TotalVenta = ventas.TotalVenta;
                ousuario.IdUsuario = ventas.IdUsuario;
                ousuario.EstadoOrdenVenta= ventas.EstadoOrdenVenta;
                //editamos registro
                _context.Entry(ousuario).State = EntityState.Modified;
                _context.SaveChanges();
                return ousuario;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return new OrdenesVenta();
            }
        }

        public bool DeleteVenta(int id)
        {
            try
            {
                var opersona = _context.OrdenesVentas.Find(id);//obtengo entidad con id
                _context.OrdenesVentas.Remove(opersona);
                _context.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
        }
    }
   
}
