using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Compurent.Web.Models
{
    public class PurchaseDetail
    {
        [Required]
        [Display(Name = "Identificación del Cliente")]
        public string Client_id { get; set; }
        [Required]
        [Display(Name = "Código del Album")]
        public int Album_id { get; set; }
        [Required]
        [Display(Name = "Total de la Compra")]
        public double Total { get; set; }
        [Display(Name = "Codigo de la Compra")]
        public int id { get; set; }
    }
}