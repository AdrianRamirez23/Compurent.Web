using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Compurent.Web.Models
{
    public class Album
    {
        [Display(Name = "Código del Álbum")]
        public int id { get; set; }
        [Required]
        [Display(Name = "Nombre del Álbum")]
        public string Name { get; set; }
    }
}