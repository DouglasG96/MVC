using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MVC.Entities;
using MVC.Interfaces;
using MVC.Models;
using MVC.ViewModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ILogin _login;


        public HomeController(ILogger<HomeController> logger, ILogin login)
        {
            _logger = logger;
            _login = login;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public ActionResult Nuevo()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Login(UsuariosViewModel usuario)
        {
            string accion = "";
            string controlador = "";
            if (ModelState.IsValid)
            {
                try
                {
                    var resp = _login.Login(usuario);
                    if(resp)
                    {
                        /*
                        HttpContext.Session.SetInt32("idUsuario", usuario.IdUsuario);
                        HttpContext.Session.SetString("nombreCompleto", usuario.NombreCompleto.ToString());
                        HttpContext.Session.SetString("correoElectronico", usuario.CorreoElectronico.ToString());
                        */
                        accion = "Index";
                        controlador = "Peliculas";
                    }
                    else
                    {
                        accion = "Index";
                        controlador = "Home";
                    }

                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
            }
            return RedirectToAction(accion, controlador);
        }

        public ActionResult LogOff()
        {

            HttpContext.Session.Clear();//Limpiar la sesión

            return RedirectToAction("Index", "Home");//Redireccionar a la vista login
        }

                [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
