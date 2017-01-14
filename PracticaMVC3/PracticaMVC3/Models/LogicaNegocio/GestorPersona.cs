using PracticaMVC3.Models.AccesoDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PracticaMVC3.Models.LogicaNegocio
{
    public class GestorPersona
    {
        RepositorioPersona repo = new RepositorioPersona();
        public void Guardar(Persona persona)
        {
            repo.Guardar(persona);
        }
        public void Eliminar(int id)
        {
           repo.Eliminar(id);
        }
        public List<Persona> ObtenerLista()
        {
            return repo.ObtenerLista();
        }
        public void Modificar(Persona id)
        {
            repo.Modificar(id);
        }
        public Persona ObtenerPorId(int id)
        {
            return repo.ObtenerPorId(id);
        }
        public List<Persona> Buscar(string parametroBusqueda)
        {
            return repo.Buscar(parametroBusqueda);
        }
    }
}