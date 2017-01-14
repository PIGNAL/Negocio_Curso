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
    public class PersonaController : Controller
    {
        // GET: Persona
        GestorPersona gestor = new GestorPersona();
        public ActionResult ObtenerLista()
        {
            var listaPersona = gestor.ObtenerLista();
            return View(listaPersona);
        }
        public ActionResult Guardar(Persona persona)
        {
            if(!ModelState.IsValid)
            {                
                return View("Crear", persona);
            }
            try
            {
                gestor.Guardar(persona);
                return RedirectToAction("ObtenerLista");
            }
            catch
            {
                ModelState.AddModelError(string.Empty, "Error");
                return View("Crear", persona);
            }
        }
        public ActionResult Crear()
        {
            return View(new PersonaViewModel());
        }
        public ActionResult PersonaEncontrada(Persona persona)
        {
            return View(persona);
        }
        public ActionResult Eliminar(int id)
        {
            gestor.Eliminar(id);
            return RedirectToAction("ObtenerLista");
        }
        public ActionResult Modificar(int id)
        {
            var personaEncontrada = gestor.ObtenerPorId(id);
            return View(personaEncontrada);
        }
        public ActionResult GuardarModificacion(Persona persona)
        {
            gestor.Modificar(persona);
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
        public ActionResult DetallePersona(string parametroBusqueda)
        {
            var resultado = gestor.Buscar(parametroBusqueda);
            if(resultado.Count==0)
            {
                ModelState.AddModelError(string.Empty,"No existe la persona esa por favor intente nuevamente");
                return View("Busqueda");
            }
            if(resultado.Count>1)
            {
                return View("ObtenerLista", resultado);
            }
            else
            {
                var persona = resultado.FirstOrDefault();
                var personaViewModel = new PersonaViewModel
                {
                    Nombre=persona.Nombre,
                    Apellido=persona.Apellido,
                    Dni=persona.Dni
                };
                return View(personaViewModel);
            }
        }
        public ActionResult BuscarPartial(string parametroBusqueda)
        {
            try
            {
                var resultado = gestor.Buscar(parametroBusqueda);
                var persona = resultado.FirstOrDefault();
                return PartialView("DetallePersona", persona.ToViewModel());
            }
            catch (Exception ex)
            {
                return Json("Error", JsonRequestBehavior.AllowGet);
            }
        }
    }
}