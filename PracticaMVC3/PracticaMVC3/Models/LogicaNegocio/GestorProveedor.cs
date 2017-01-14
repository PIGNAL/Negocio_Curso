using PracticaMVC3.Models.AccesoDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PracticaMVC3.Models.LogicaNegocio
{
    public class GestorProveedor
    {
        RepositorioProveedor repo = new RepositorioProveedor();
        public void Guardar(Proveedor proveedor)
        {
            repo.Guardar(proveedor);
        }
        public Proveedor ObtenerPorId(int id)
        {
            return repo.ObtenerPorId(id);
        }
        public List<Proveedor> ObtenerLista()
        {
            return repo.ObtenerLista();
        }
        public void Eliminar(int id)
        {
            repo.Eliminar(id);
        }
        public void Modificar(Proveedor proveedorModificado)
        {
            repo.Modificar(proveedorModificado);
        }
        public List<Proveedor> Buscar(string parametroBusqueda)
        {
            return repo.Buscar(parametroBusqueda);
        }
    }
}