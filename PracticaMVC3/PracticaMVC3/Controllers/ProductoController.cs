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
    public class ProductoController : Controller
    {
        // GET: Producto
        GestorProducto gestor = new GestorProducto();
        public ActionResult ObtenerLista()
        {
            var listaProducto = gestor.ObtenerLista();
            return View(listaProducto);
        }
        public ActionResult Guardar(Producto producto)
        {
            if (!ModelState.IsValid)
            {
                return View("Crear", producto);
            }
            try
            {
                gestor.Guardar(producto);
                return RedirectToAction("ObtenerLista");
            }
            catch
            {
                ModelState.AddModelError(string.Empty, "Error");
                return View("Crear", producto);
            }
        }
        public ActionResult Crear()
        {
            return View();
        }
        public ActionResult Eliminar(int id)
        {
            gestor.Eliminar(id);
            return RedirectToAction("ObtenerLista");
        }
        public ActionResult Modificar(int id)
        {
            var productoEncontrado = gestor.ObtenerPorId(id);
            return View(productoEncontrado);
        }
        public ActionResult GuardarModificacion(Producto producto)
        {
            gestor.Modificar(producto);
            return RedirectToAction("ObtenerLista");
        }
        protected override void OnException(ExceptionContext filterContext)
        {
            filterContext.ExceptionHandled = true;
            filterContext.Result = new ViewResult
            {
                ViewName = "/Views/Error/Error.cshtml"
            };
        }
        public ActionResult Busqueda()
        {
            return View();
        }
        public ActionResult DetalleProducto(string parametroBusqueda)
        {
            var resultado = gestor.Buscar(parametroBusqueda);
            if (resultado.Count == 0)
            {
                ModelState.AddModelError(string.Empty, "No existe el producto por favor intente nuevamente");
                return View("Busqueda");
            }
            if (resultado.Count > 1)
            {
                return View("ObtenerLista", resultado);
            }
            else
            {
                var producto = resultado.FirstOrDefault();
                var productoViewModel = new ProductoViewModel
                {
                    Nombre = producto.Nombre,
                    Precio = producto.Precio,
                    Codigo = producto.Codigo
                };
                return View(productoViewModel);
            }
        }
        public ActionResult BuscarPartial(string parametroBusqueda)
        {
            try
            {
                var resultado = gestor.Buscar(parametroBusqueda);
                var producto = resultado.FirstOrDefault();
                return PartialView("DetalleProducto", producto.ToViewModel());
            }
            catch (Exception ex)
            {
                return Json("Error", JsonRequestBehavior.AllowGet);
            }
        }
    }
}
