using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PracticaMVC3.Models.AccesoDatos
{
    
    public class RepositorioVenta
    {
        TallerEntities baseDatos = new TallerEntities();
        public List<Venta>Listar()
        {
            return baseDatos.Venta.ToList();
        }
        public void Guardar(Venta venta)
        {
            baseDatos.Venta.Add(venta);
            baseDatos.SaveChanges();
        }
        public void Eliminar(int id)
        {
            var venta = baseDatos.Venta.FirstOrDefault(x => x.Id == id);
            baseDatos.Venta.Remove(venta);
            baseDatos.SaveChanges();
        }

    }
}