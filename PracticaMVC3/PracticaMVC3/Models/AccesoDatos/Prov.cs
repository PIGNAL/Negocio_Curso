using PracticaMVC3.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PracticaMVC3.Models.AccesoDatos
{
    public partial class Proveedor
    {
        public ProveedorViewModel ToViewModel()
        {
            return new ProveedorViewModel
            {
                Nombre = this.Nombre,
                Direccion = this.Direccion,
                Codigo = this.Codigo
            };
        }

    }
}