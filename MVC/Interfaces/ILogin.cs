using MVC.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC.Interfaces
{
    public interface ILogin
    {
        bool Login(UsuariosViewModel user);
    }
}
