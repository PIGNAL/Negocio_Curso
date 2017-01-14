using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PracticaMVC3.ViewModels
{
    public class PersonaViewModel
    {
        [Required]
        public string Nombre { get; set; }
        [Required]
        public string Apellido { get; set; }
        [Required]
        public string Dni { get; set; }
        [HiddenInput(DisplayValue =false)]
        public int Id { get; set; }
    }
}