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
    public class RentasController : Controller
    {
        private readonly IRentas _rentas;

        public RentasController(IRentas rentas)
        {
            _rentas = rentas;
        }

        // GET: RentasController
        public ActionResult Index()
        {
            List<RentasViewModel> list;
            list = _rentas.GetRentas();
            return View(list);
        }

        // GET: RentasController/Details/5
        public ActionResult Details(int id)
        {
            RentasViewModel usvm = new RentasViewModel();
            usvm = _rentas.GetRentaById(id);
            return View(usvm);
        }

        // GET: RentasController/Create
        public ActionResult CreateView()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(RentasViewModel rentas)
        {
            string accion = "";
            string controlador = "";
            try
            {
                //validar datos
                if (ModelState.IsValid)
                {
                    rentas.EstadoOrdenRenta = 1;
                    rentas.FechaHoraOrdenRenta = DateTime.Now;
                    rentas.FechaVencimiento = DateTime.Now;
                    rentas.IdUsuario = 1;
                    var resp = _rentas.CreateRenta(rentas);

                   if (resp == null)
                   {
                        accion = "Index";
                        controlador = "Rentas";
                   }
                   else
                   {
                       return RedirectToAction("Index", "Rentas");
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
        // POST: RentasController/Create
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

        // GET: RentasController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: RentasController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(RentasViewModel rentas)
        {
            string accion = "";
            string controlador = "";
            try
            {
                //validar datos
                if (ModelState.IsValid)
                {
                    var resp = _rentas.UpdateRenta(rentas);

                    if (resp == null)
                    {
                        accion = "Index";
                        controlador = "Rentas";
                    }
                    else
                    {
                        return RedirectToAction("Index", "Rentas");
                    }
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return RedirectToAction(accion, controlador);
        }

        // GET: RentasController/Delete/5
        public ActionResult Delete(int id)
        {
            try
            {
                _rentas.DeleteRenta(id);
            }
            catch(Exception e)
            {
                Console.WriteLine(e);
            }
            return RedirectToAction("Index", "Rentas");
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
