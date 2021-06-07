using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Projeto.DataAccess;
using Projeto.Models;


namespace Projeto.Controllers
{
    public class AcaoController : Controller
    {
        public IActionResult Index()
        {
            AcaoDAO dao = new AcaoDAO();
            List<Acao> acao = dao.listaAcao();
            
            return View(acao);
        }
    }
}
