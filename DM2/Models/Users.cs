using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DM2.Models
{
    public class Users
    {
        [Key]
        public int IdUser { get; set; }
        [StringLength(70)]
        [Display(Name = "Usuario")]
        public string UserName { get; set; }
        [StringLength(50)]
        public string Nombre { get; set; }
        [StringLength(50)]
        public string Apellido { get; set; }
        [StringLength(100)]
        [Display(Name = "Imagen")]
        public string ImagenURL { get; set; }

        public List<Articles> Articles { get; set; }
    }
}