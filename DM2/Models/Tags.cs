using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DM2.Models
{
    public class Tags
    {
        [Key]
        public int IdTag { get; set; }
        [StringLength(30)]
        public string NombreTag { get; set; }

        public List<ArticulosTag> ArticulosTags { get; set; }
    }
}