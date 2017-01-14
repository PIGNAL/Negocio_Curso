using PracticaMVC3.Models.AccesoDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PracticaMVC3.Models.LogicaNegocio
{
    public class GestorProducto
    {
        RepositorioProducto repo = new RepositorioProducto(); 
        public void Guardar(Producto producto)
        {
            repo.Guardar(producto);
        }
        public void Eliminar(int id)
        {
            repo.Eliminar(id);
        }
        public Producto ObtenerPorId(int id)
        {
            return repo.ObtenerPorId(id);
        }
        public List<Producto> ObtenerLista()
        {
          return repo.ObtenerLista();
        }
        public void Modificar(Producto producto)
        {
            repo.Modificar(producto);
        }
        public List<Producto> Buscar(string parametroBusqueda)
        {
            return repo.Buscar(parametroBusqueda);
        }

    }
}