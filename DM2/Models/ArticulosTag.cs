using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DM2.Models
{
    public class ArticulosTag
    {
        [Key]
        public int IdArtTag { get; set; }
        public int IdTag { get; set; }
        public int IdArticle { get; set; }

        [Display(Name = "Tag")]
        public virtual Tags Tags { get; set; }
        [Display(Name = "Artículo")]
        public virtual Articles Articles { get; set; }
    }
}