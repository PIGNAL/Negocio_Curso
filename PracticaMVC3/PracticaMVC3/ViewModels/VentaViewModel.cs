using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PracticaMVC3.ViewModels
{
    public class VentaViewModel
    {
        [Required]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime Fecha { get; set; }
        [Required]
        [Range(0, 9999999999999999.99)]
        public Decimal Total { get; set; }
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }
    }
}