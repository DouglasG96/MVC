using Microsoft.AspNetCore.Http;
using MVC.Entities;
using MVC.Interfaces;
using MVC.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC.Models
{
    public class LoginModel : ILogin
    {
        private PeliculasContext _context;

        public LoginModel(PeliculasContext context)
        {
            _context = context;            
        }

        public bool Login(UsuariosViewModel usuario)
        {
            try
            {
                var user = _context.Usuarios.FirstOrDefault(x => x.CorreoElectronico == usuario.CorreoElectronico && x.Contrasena == usuario.Contrasena);
                if (user == null)
                {
                    return false;
                }
                else
                {
    
                    return true;
                }
            }
            catch (Exception e)
            {
                throw;
            }
        }
    }
}
