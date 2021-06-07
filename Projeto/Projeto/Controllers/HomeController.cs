using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Projeto.Models;
using Projeto.DataAccess;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public ActionResult Login()
        {
            return View("Login");
        }

        [HttpPost]
        public ActionResult Login(LogInModel model)
        {
            UtilizadorDAO dAO = new UtilizadorDAO();
            bool id = dAO.Login(model.Username, model.Password);

            if (id)
                ViewBag.SuccessMessage = "Login Successful";
            else
                ViewBag.DuplicateMessage = "Username already exists!";

            return View("Index");
        }

        public ActionResult Registration()
        {
            return View("Registration");
        }

        [HttpPost]
        public ActionResult Registration(CreateModel model)
        {
            Utilizador u = new Utilizador(-1, model.PrimeiroNome, model.UltimoNome, model.Username, Utilizador.HashPassword(model.Password),
                                             model.Email, model.Experiencia, model.CapacidadeMonetaria, model.Localizacao);
            UtilizadorDAO dAO = new UtilizadorDAO();

            bool val = dAO.Insert(u);

            if (val)
                ViewBag.SuccessMessage = "Registation Successful";
            else
                ViewBag.DuplicateMessage = "Username already exists!";

            return View("Index");
        }
    }
}
