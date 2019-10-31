using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DM2.Models
{
    public class Sections
    {
        [Key]
        public int IdSection { get; set; }

        [StringLength(50)]
        [Display(Name = "Sección")]
        public string Nombre { get; set; }

        public List<Articles> Articles { get; set; }
    }
}