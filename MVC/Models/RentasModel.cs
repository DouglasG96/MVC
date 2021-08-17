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
    public class RentasModel : IRentas
    {
        private PeliculasContext _context;
        public RentasModel(PeliculasContext context)
        {
            _context = context;
        }

        public List<RentasViewModel> GetRentas()
        {
            try
            {
                return (from b in _context.OrdenesRenta
                        select new RentasViewModel
                        {
                            IdOrdenRenta = b.IdOrdenRenta,
                            FechaHoraOrdenRenta = b.FechaHoraOrdenRenta,
                            FechaVencimiento = b.FechaVencimiento,
                            IdUsuario = b.IdUsuario,
                            EstadoOrdenRenta = b.EstadoOrdenRenta
                        }).ToList();              
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;

            }
        }

        public RentasViewModel GetRentaById(int id)
        {
            try
            {
                RentasViewModel model = new RentasViewModel();
                var orenta = _context.OrdenesRenta.Find(id);//obtenemos registro por medio de id
                model.IdOrdenRenta = orenta.IdOrdenRenta;
                model.FechaHoraOrdenRenta = orenta.FechaHoraOrdenRenta;
                model.FechaVencimiento = orenta.FechaVencimiento;
                model.IdUsuario = orenta.IdUsuario;
                model.EstadoOrdenRenta = orenta.EstadoOrdenRenta;
                return model;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return new RentasViewModel();
            }
        }

        public OrdenesRentum CreateRenta(RentasViewModel rentas)
        {
            var orentas = new OrdenesRentum();
            var orentasDetalle = new OrdenesRentasDetalle();
            try
            {
                orentas.IdOrdenRenta = rentas.IdOrdenRenta;
                orentas.FechaHoraOrdenRenta = rentas.FechaHoraOrdenRenta;
                orentas.FechaVencimiento = rentas.FechaVencimiento;
                orentas.IdUsuario = rentas.IdUsuario;
                orentas.EstadoOrdenRenta = rentas.EstadoOrdenRenta;

                _context.OrdenesRenta.Add(orentas);
                _context.SaveChanges();

                orentasDetalle.IdOrdenRenta = orentas.IdOrdenRenta;
                orentasDetalle.IdPelicula = rentas.IdPelicula;
                orentasDetalle.Cantidad = rentas.Cantidad;
                orentasDetalle.EstadoDetalle = 1;;

                _context.OrdenesRenta.Add(orentas);
                _context.SaveChanges();

                return orentas;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            return orentas;
        }

        public OrdenesRentum UpdateRenta(RentasViewModel rentas)
        {
            try
            {
                var orentas = _context.OrdenesRenta.Find(rentas.IdOrdenRenta);//obtenemos registro por medio de id
                var orentasDetalle = _context.OrdenesRentasDetalles.Find(rentas.IdOrdenRenta);//obtenemos registro por medio de id
                orentas.FechaHoraOrdenRenta = rentas.FechaHoraOrdenRenta;
                orentas.FechaVencimiento= rentas.FechaVencimiento;
                orentas.IdUsuario = rentas.IdUsuario;
                orentas.EstadoOrdenRenta = rentas.EstadoOrdenRenta;
                orentasDetalle.IdPelicula = rentas.IdPelicula;
                orentasDetalle.Cantidad = rentas.Cantidad;
                orentasDetalle.EstadoDetalle = rentas.EstadoDetalle;
                //editamos registro
                _context.Entry(orentas).State = EntityState.Modified;
                _context.SaveChanges();

                //editamos Detalles
                _context.Entry(orentasDetalle).State = EntityState.Modified;
                _context.SaveChanges();
                return orentas;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return new OrdenesRentum();
            }
        }

        public bool DeleteRenta(int id)
        {
            try
            {
                var orentas = _context.OrdenesRenta.Find(id);//obtengo entidad con id
                var orentasDetalles = _context.OrdenesRentasDetalles.Find(id);//obtengo entidad con id
                _context.OrdenesRenta.Remove(orentas);
                _context.SaveChanges();

                _context.OrdenesRentasDetalles.Remove(orentasDetalles);
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
