using MVC.Entities;
using MVC.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC.Interfaces
{
    public interface IUsuarios
    {
        List<UsuariosViewModel> GetUsuarios();
        Usuario CreateUsuario(UsuariosViewModel usuario);
        Usuario UpdateUsuario(UsuariosViewModel usuario);
        UsuariosViewModel GetUsuarioById(int id);
        bool DeleteUsuario(int id);        
    }
}
