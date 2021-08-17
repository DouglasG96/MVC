using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MVC.Entities;
using MVC.Interfaces;
using MVC.Models;
using MVC.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC.Controllers
{
    public class PeliculasController : Controller
    {
        private readonly IPeliculas _peliculas;

        public PeliculasController(IPeliculas peliculas)
        {
            _peliculas = peliculas;
        }

        // GET: PeliculasController
        public ActionResult Index()
        {
            List<PeliculasViewModel> list;
            list = _peliculas.GetPeliculas();
            return View(list);
        }

        // GET: PeliculasController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: PeliculasController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PeliculasController/Create
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

        // GET: PeliculasController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: PeliculasController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
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

        // GET: PeliculasController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: PeliculasController/Delete/5
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
