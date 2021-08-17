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
    public class VentasController : Controller
    {
        private readonly IVentas _IVentas;

        public VentasController(IVentas ventas)
        {
            _IVentas = ventas;
        }

        // GET: UsuariosController
        public ActionResult Index()
        {
            List<VentasViewModel> list;
            list = _IVentas.GetVentas();
            return View(list);
        }

        // GET: UsuariosController/Details/5
        public ActionResult Details(int id)
        {
            VentasViewModel usvm = new VentasViewModel();
            usvm = _IVentas.GetVentaById(id);
            return View(usvm);
        }

        // GET: UsuariosController/Create
        public ActionResult CreateView()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(VentasViewModel ventas)
        {
            string accion = "";
            string controlador = "";
            try
            {
                //validar datos
                if (ModelState.IsValid)
                {
                    var resp = _IVentas.CreateVentas(ventas);

                   if (resp == null)
                   {
                        accion = "Index";
                        controlador = "Ventas";
                   }
                   else
                   {
                       return RedirectToAction("Index", "Ventas");
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
        public ActionResult Edit(VentasViewModel ventas)
        {
            string accion = "";
            string controlador = "";
            try
            {
                //validar datos
                if (ModelState.IsValid)
                {
                    var resp = _IVentas.UpdateVentas(ventas);

                    if (resp == null)
                    {
                        accion = "Index";
                        controlador = "Ventas";
                    }
                    else
                    {
                        return RedirectToAction("Index", "Ventas");
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
                _IVentas.DeleteVenta(id);
            }
            catch(Exception e)
            {
                Console.WriteLine(e);
            }
            return RedirectToAction("Index", "Ventas");
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
