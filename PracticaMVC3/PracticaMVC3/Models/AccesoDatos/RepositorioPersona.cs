using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PracticaMVC3.Models.AccesoDatos
{
    public class RepositorioPersona
    {
        TallerEntities1 baseDatos = new TallerEntities1();
        public void Guardar(Persona persona)
        {
            baseDatos.Persona.Add(persona);
            baseDatos.SaveChanges();
        }

        public List<Persona> ObtenerLista()
        {
            return baseDatos.Persona.ToList();
        }
        public void Eliminar(int id)
        {
            var persona = baseDatos.Persona.FirstOrDefault(x => x.Id == id);
            baseDatos.Persona.Remove(persona);
            baseDatos.SaveChanges();
        }
        public Persona ObtenerPorId(int id)
        {
            var personaObtenido = baseDatos.Persona.FirstOrDefault(x => x.Id == id);
            return personaObtenido;
        }
        public void Modificar(Persona persona)
        {
            var personaModificar = baseDatos.Persona.FirstOrDefault(x => x.Id == persona.Id);
            personaModificar.Apellido = persona.Apellido;
            personaModificar.Nombre = persona.Nombre;
            personaModificar.Dni = persona.Dni;
            baseDatos.SaveChanges();
        }
        public List<Persona> Buscar(string parametroBusqueda)
        {
            var personaEncontrada = baseDatos.Persona.Where(x => x.Nombre.Contains(parametroBusqueda)
            || x.Apellido.Contains(parametroBusqueda) 
            || x.Dni.Contains(parametroBusqueda)).ToList();
            return personaEncontrada;
        }
    }
}