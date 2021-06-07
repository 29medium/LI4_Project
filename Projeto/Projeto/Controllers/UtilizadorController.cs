using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Projeto.DataAccess;
using Projeto.Models;

namespace Projeto.Controllers
{
    public class UtilizadorController : Controller
    {
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

            return new RedirectResult("Home/Index", false);
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

            return View("Login");
        }
    }
}
