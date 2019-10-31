using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DM2.Models
{
    public class Articles
    {
        [Key]
        public int Id { get; set; }
        [StringLength(100)]
        public string URL { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy/MM/dd hh:mm}")] 
        public DateTime Fecha { get; set; }
        [StringLength(100)]
        public string Nombre { get; set; }

        [Display(Name = "Nota")]
        [AllowHtml]
        public string Body { get; set; }

        [StringLength(100)]
        [Display(Name = "Imagen")]
        public string ImgURL { get; set; }
        public int IdUser { get; set; }
        public int IdSection { get; set; }

        [Display(Name = "Sección")]
        public Sections Sections { get; set; }
        [Display(Name = "Usuario")]
        public Users Users { get; set; }
    }
}