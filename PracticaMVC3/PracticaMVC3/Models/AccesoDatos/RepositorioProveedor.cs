using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PracticaMVC3.Models.AccesoDatos
{
    public class RepositorioProveedor
    {
        Taller baseDatos = new Taller();
        public void Guardar(Proveedor proveedor)
        {
            baseDatos.Proveedor.Add(proveedor);
            baseDatos.SaveChanges();
        }
        public Proveedor ObtenerPorId(int id)
        {
            var proveedorObtenido = baseDatos.Proveedor.FirstOrDefault(x => x.Id == id);
            return proveedorObtenido;
        }
        public List<Proveedor> ObtenerLista()
        {
            return baseDatos.Proveedor.ToList();
        }
        public void Eliminar(int id)
        {
            var proveedorEncontrado = baseDatos.Proveedor.FirstOrDefault(x => x.Id == id);
            baseDatos.Proveedor.Remove(proveedorEncontrado);
            baseDatos.SaveChanges();
        }
        public void Modificar(Proveedor proveedor)
        {
            var proveedorModificar = baseDatos.Proveedor.FirstOrDefault(x => x.Id == proveedor.Id);
            proveedorModificar.Nombre = proveedor.Nombre;
            proveedorModificar.Direccion = proveedor.Direccion;
            proveedorModificar.Codigo = proveedor.Codigo;
            baseDatos.SaveChanges();
        }
        public List<Proveedor> Buscar(string parametroBusqueda)
        {
            var proveedorEncontrado = baseDatos.Proveedor.Where(x => x.Nombre.Contains(parametroBusqueda)
            || x.Direccion.Contains(parametroBusqueda)
            || x.Codigo.Contains(parametroBusqueda)).ToList();
            return proveedorEncontrado;
        }
    }
}