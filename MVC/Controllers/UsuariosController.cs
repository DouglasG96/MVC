using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MVC.Interfaces;
using MVC.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace MVC.Controllers
{
    public class UsuariosController : Controller
    {
        private readonly IUsuarios _Iusuarios;

        public UsuariosController(IUsuarios usuarios)
        {
            _Iusuarios = usuarios;
        }

        // GET: UsuariosController
        public ActionResult Index()
        {
            List<UsuariosViewModel> list;
            list = _Iusuarios.GetUsuarios();
            return View(list);
        }

        // GET: UsuariosController/Details/5
        public ActionResult Details(int id)
        {
            UsuariosViewModel usvm = new UsuariosViewModel();
            usvm = _Iusuarios.GetUsuarioById(id);
            return View(usvm);
        }

        // GET: UsuariosController/Create
        public ActionResult CreateView()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(UsuariosViewModel persona)
        {
            string accion = "";
            string controlador = "";
            try
            {
                //validar datos
                if (ModelState.IsValid)
                {
                    var resp = _Iusuarios.CreateUsuario(persona);

                   if (resp == null)
                   {
                        accion = "Index";
                        controlador = "Usuarios";
                   }
                   else
                   {
                       return RedirectToAction("Index", "Usuarios");
                   }
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return RedirectToAction(accion, controlador);
        }

        /*
        // POST: UsuariosController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
        */

        // GET: UsuariosController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: UsuariosController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(UsuariosViewModel usuario)
        {
            string accion = "";
            string controlador = "";
            try
            {
                //validar datos
                if (ModelState.IsValid)
                {
                    var resp = _Iusuarios.UpdateUsuario(usuario);

                    if (resp == null)
                    {
                        accion = "Index";
                        controlador = "Usuarios";
                    }
                    else
                    {
                        return RedirectToAction("Index", "Usuarios");
                    }
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return RedirectToAction(accion, controlador);
        }

        // GET: UsuariosController/Delete/5
        public ActionResult Delete(int id)
        {
            try
            {
                _Iusuarios.DeleteUsuario(id);
            }
            catch(Exception e)
            {
                Console.WriteLine(e);
            }
            return RedirectToAction("Index", "Usuarios");
        }

        // POST: UsuariosController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
