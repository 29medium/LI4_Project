using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Projeto.DataAccess;
using Projeto.Models;

namespace Projeto.Controllers
{
    public class EmpresaController : Controller
    {
        public IActionResult Index()
        {
            EmpresaDAO dao = new EmpresaDAO();
            List<Empresa> empresas = dao.listaEmpresas();
            return View(empresas);
        }
    }
}
