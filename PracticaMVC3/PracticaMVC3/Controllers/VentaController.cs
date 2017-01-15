using PracticaMVC3.Models.LogicaNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PracticaMVC3.Controllers
{
    public class VentaController : Controller
    {
        GestorVenta gestor = new GestorVenta();
        public ActionResult MenuVenta()
        {
            return View();
        }
        public ActionResult ListarVenta()
        {
            var listaVenta = gestor.Listar();
            return View(listaVenta);
        }
    }
}