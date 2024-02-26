using MVC_AziendaEdile.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_AziendaEdile.Controllers
{
    public class DipendenteController : Controller
    {
        // GET: Dipendente
        public ActionResult Index()
        {
            // SELECT * FROM Dipendente 
            return View();
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create( Dipendente d )
        {
            return View();
        }
    }
}