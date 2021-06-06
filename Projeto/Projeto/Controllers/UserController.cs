using System;
using System.Linq;
using System.Threading.Tasks;
using System.Threading;
using Microsoft.AspNetCore.Mvc;
using Projeto.Models;
using Projeto.DataAccess;
using System.Collections.Generic;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Projeto.Controllers
{
    public class UserController : Controller
    {
    	public ActionResult Login(LogInModel model)
        {
            UserDAO dAO = new UserDAO();
            bool id = dAO.LogIn(model.Username, model.Password);

            if (id)
            	ViewBag.SuccessMessage = "Login Successful";
            else
            	ViewBag.DuplicateMessage = "Username already exists!";

            return View(model);
    	}

    	public ActionResult Registation(CreateModel model)
        {
            Utilizador u = new Utilizador(-1,model.primeiroNome, model.ultimoNome, model.username, Utilizador.HashPassword(model.password),
             								model.email, model.experiencia,model.capacidadeMonetaria,model.areaInteresse,model.coordX, model.coordY);
            UserDAO dAO = new UserDAO();

            bool val = dAO.Insert(u);

            if (val)
            	ViewBag.SuccessMessage = "Registation Successful";
            else
            	ViewBag.DuplicateMessage = "Username already exists!";

            return View(model);
    	}
}