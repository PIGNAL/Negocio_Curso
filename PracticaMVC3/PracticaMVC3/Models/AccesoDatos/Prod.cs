using PracticaMVC3.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PracticaMVC3.Models.AccesoDatos
{
    public partial class Producto
    {
        public ProductoViewModel ToViewModel()
        {
            return new ProductoViewModel
            {
                Nombre = this.Nombre,
                Precio = this.Precio,
                Codigo = this.Codigo
            };
        }

    }
}