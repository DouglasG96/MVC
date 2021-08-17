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
    public class UsuariosModel : IUsuarios
    {
        private PeliculasContext _context;
        public UsuariosModel(PeliculasContext context)
        {
            _context = context;
        }

        public List<UsuariosViewModel> GetUsuarios()
        {
            try
            {
                return (from b in _context.Usuarios
                        select new UsuariosViewModel
                        {
                            IdUsuario = b.IdUsuario,
                            NombreCompleto = b.NombreCompleto,
                            Dui = b.Dui,
                            TelefonoContacto = b.TelefonoContacto,
                            CorreoElectronico = b.CorreoElectronico
                        }).ToList();              
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;

            }
        }

        public UsuariosViewModel GetUsuarioById(int id)
        {
            try
            {
                UsuariosViewModel model = new UsuariosViewModel();
                var ousuario = _context.Usuarios.Find(id);//obtenemos registro por medio de id
                model.IdUsuario = ousuario.IdUsuario;
                model.Nombres = ousuario.Nombres;
                model.Apellidos = ousuario.Apellidos;
                model.Dui = ousuario.Dui;
                model.TelefonoContacto = ousuario.TelefonoContacto;
                model.CorreoElectronico = ousuario.CorreoElectronico;
                return model;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return new UsuariosViewModel();
            }
        }

        public Usuario CreateUsuario(UsuariosViewModel usuario)
        {
            var ousuario = new Usuario();
            try
            {                 
                ousuario.Nombres = usuario.Nombres;
                ousuario.Apellidos = usuario.Apellidos;
                ousuario.NombreCompleto = (usuario.Nombres + ' ' + usuario.Apellidos);
                ousuario.Dui = usuario.Dui;
                ousuario.CorreoElectronico = usuario.CorreoElectronico;
                ousuario.Contrasena = usuario.Contrasena;

                _context.Usuarios.Add(ousuario);
                _context.SaveChanges();
                return ousuario;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            return ousuario;
        }

        public Usuario UpdateUsuario(UsuariosViewModel usuario)
        {
            try
            {
                var ousuario = _context.Usuarios.Find(usuario.IdUsuario);//obtenemos registro por medio de id
                ousuario.Nombres = usuario.Nombres;
                ousuario.Apellidos = usuario.Apellidos;
                ousuario.NombreCompleto = usuario.NombreCompleto;
                ousuario.Dui = usuario.Dui;
                ousuario.CorreoElectronico = usuario.CorreoElectronico;
                ousuario.Contrasena = usuario.Contrasena;
                //editamos registro
                _context.Entry(ousuario).State = EntityState.Modified;
                _context.SaveChanges();
                return ousuario;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return new Usuario();
            }
        }

        public bool DeleteUsuario(int id)
        {
            try
            {
                var opersona = _context.Usuarios.Find(id);//obtengo entidad con id
                _context.Usuarios.Remove(opersona);
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
