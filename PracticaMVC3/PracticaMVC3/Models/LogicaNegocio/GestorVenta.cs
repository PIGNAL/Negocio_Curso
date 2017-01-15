using PracticaMVC3.Models.AccesoDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PracticaMVC3.Models.LogicaNegocio
{
    public class GestorVenta
    {
        RepositorioVenta repo = new RepositorioVenta();
        public List<Venta> Listar()
        {
            return repo.Listar();
        }
    }
}