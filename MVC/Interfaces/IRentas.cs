using MVC.Entities;
using MVC.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC.Interfaces
{
    public interface IRentas
    {
        List<RentasViewModel> GetRentas();
        OrdenesRentum CreateRenta(RentasViewModel rentas);
        OrdenesRentum UpdateRenta(RentasViewModel rentas);
        RentasViewModel GetRentaById(int id);
        bool DeleteRenta(int id);        
    }
}
