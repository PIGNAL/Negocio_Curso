using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PracticaMVC3.Models.AccesoDatos
{
    public class RepositorioProducto
    {
        Taller baseDatos = new Taller();
        public void Guardar(Producto producto)
        {
            baseDatos.Producto.Add(producto);
            baseDatos.SaveChanges();
        }
        public void Eliminar(int id)
        {
            var productoEncontrado = baseDatos.Producto.FirstOrDefault(x => x.Id == id);
            baseDatos.Producto.Remove(productoEncontrado);
            baseDatos.SaveChanges();
        }
        public Producto ObtenerPorId(int id)
        {
            var productoObtenido = baseDatos.Producto.FirstOrDefault(x => x.Id == id);
            return productoObtenido;
        }
        public List<Producto>ObtenerLista()
        {
            return baseDatos.Producto.ToList();
        }
        public void Modificar(Producto producto)
        {
            var productoModificar = baseDatos.Producto.FirstOrDefault(x => x.Id == producto.Id);
            productoModificar.Nombre = producto.Nombre;
            productoModificar.Precio = producto.Precio;
            productoModificar.Codigo = producto.Codigo;
            baseDatos.SaveChanges();
        }
        public List<Producto> Buscar(string parametroBusqueda)
        {
            var productoEncontrado = baseDatos.Producto.Where(x => x.Nombre.Contains(parametroBusqueda)
            || x.Precio.Contains(parametroBusqueda)
            || x.Codigo.Contains(parametroBusqueda)).ToList();
            return productoEncontrado;
        }
    }
}