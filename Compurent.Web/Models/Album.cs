using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Compurent.Web.Models
{
    public class Album
    {
        [Display(Name = "Código del Album")]
        public int id { get; set; }
        [Display(Name = "Nombre del Album")]
        public string Name { get; set; }
    }
}