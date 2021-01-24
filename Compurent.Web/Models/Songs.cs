using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Compurent.Web.Models
{
    public class Songs
    {
        [Display(Name = "Código de la Canción")]
        public int id { get; set; }
        [Required]
        [Display(Name = "Nombre de la Canción")]
        public string Name { get; set; }
        [Required]
        [Display(Name = "Código del Álbum")]
        public int Album_id { get; set; }
    }
}