using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Salão.Models
{
    public class AdminModel
    {

        public int ID { get; set; }

        [Display(Name = "Nome")]
        [Required]
        public string Name { get; set; }

        [Display(Name = "Email")]
        [Required]
        public string Email { get; set; }

        [Display(Name = "Celular")]
        [Required]
        public string Cel { get; set; }

        [Display(Name = "Função")]
        [Required]
        public string Function { get; set; }

        public ApplicationUser User { get; set; }
    }
}