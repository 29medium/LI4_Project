using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Projeto.DataAccess;
using Projeto.Models;

namespace Projeto.Controllers
{
    public class MercadoController : Controller
    {
        public IActionResult Index()
        {
            MercadoDAO dao = new MercadoDAO();
            List < Mercado > m = dao.listaMercado();

            return View(m);
        }
    }
}
