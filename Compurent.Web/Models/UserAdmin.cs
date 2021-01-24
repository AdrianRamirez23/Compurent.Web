using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Compurent.Web.Models
{
    public class UserAdmin
    {
        [Required]
        public string id { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string NameUser { get; set; }
        [Required]
        public string EmailUser { get; set; }
        [Required]
        public string Adress { get; set; }
        [Required]
        public string PhoneUser { get; set; }
    }
}