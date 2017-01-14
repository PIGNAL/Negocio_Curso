using PracticaMVC3.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PracticaMVC3.Models.AccesoDatos
{
    public partial class Persona
    {
        public PersonaViewModel ToViewModel()
        {
            return new PersonaViewModel
            {
                Apellido = this.Apellido,
                Nombre = this.Nombre,
                Dni = this.Dni
            };
        }
        
    }
}