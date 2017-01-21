using PracticaMVC3.Models.AccesoDatos;
using PracticaMVC3.Models.LogicaNegocio;
using PracticaMVC3.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PracticaMVC3.Controllers
{
    public class VentaController : Controller
    {
        GestorProducto gestorPro = new GestorProducto();
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
        public ActionResult Guardar(Venta venta)
        {
            if (!ModelState.IsValid)
            {
                return View("Crear", venta);
            }
            try
            {
                gestor.Guardar(venta);
                return RedirectToAction("ObtenerLista");
            }
            catch
            {
                ModelState.AddModelError(string.Empty, "Error");
                return View("Crear", venta);
            }
       
        }
        public ActionResult Crear()
        {
            return View(new VentaViewModel());
        }
        public ActionResult Venta()
        {
            var listaProducto = gestorPro.ObtenerLista();
            return View(listaProducto);
        }
    }
}