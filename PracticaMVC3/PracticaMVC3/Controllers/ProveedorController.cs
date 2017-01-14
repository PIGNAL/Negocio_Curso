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
    public class ProveedorController : Controller
    {
        // GET: Proveedor
        GestorProveedor gestor = new GestorProveedor();
        public ActionResult ObtenerLista()
        {
            var listaProveedor = gestor.ObtenerLista();
            return View(listaProveedor);
        }
        public ActionResult Guardar(Proveedor proveedor)
        {
            if (!ModelState.IsValid)
            {
                return View("Crear", proveedor);
            }
            try
            {
                gestor.Guardar(proveedor);
                return RedirectToAction("ObtenerLista");
            }
            catch
            {
                ModelState.AddModelError(string.Empty, "Error");
                return View("Crear", proveedor);
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
            var proveedorEncontrado = gestor.ObtenerPorId(id);
            return View(proveedorEncontrado);
        }
        public ActionResult GuardarModificacion(Proveedor proveedor)
        {
            gestor.Modificar(proveedor);
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
        public ActionResult DetalleProveedor(string parametroBusqueda)
        {
            var resultado = gestor.Buscar(parametroBusqueda);
            if (resultado.Count == 0)
            {
                ModelState.AddModelError(string.Empty, "No existe la persona esa por favor intente nuevamente");
                return View("Busqueda");
            }
            if (resultado.Count > 1)
            {
                return View("ObtenerLista", resultado);
            }
            else
            {
                var proveedor = resultado.FirstOrDefault();
                var proveedorViewModel = new ProveedorViewModel
                {
                    Nombre = proveedor.Nombre,
                    Direccion = proveedor.Direccion,
                    Codigo = proveedor.Codigo
                };
                return View(proveedorViewModel);
            }
        }
        public ActionResult BuscarPartial(string parametroBusqueda)
        {
            try
            {
                var resultado = gestor.Buscar(parametroBusqueda);
                var proveedor = resultado.FirstOrDefault();
                return PartialView("DetalleProducto", proveedor.ToViewModel());
            }
            catch (Exception ex)
            {
                return Json("Error", JsonRequestBehavior.AllowGet);
            }
        }
    }
}