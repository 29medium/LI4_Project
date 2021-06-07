using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto.Controllers
{
    public class MercadoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
