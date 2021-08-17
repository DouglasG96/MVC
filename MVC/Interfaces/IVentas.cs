using MVC.Entities;
using MVC.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC.Interfaces
{
    public interface IVentas
    {
        List<VentasViewModel> GetVentas();
        OrdenesVenta CreateVentas(VentasViewModel ventas);
        OrdenesVenta UpdateVentas(VentasViewModel ventas);
        VentasViewModel GetVentaById(int id);
        bool DeleteVenta(int id);        
    }
}
