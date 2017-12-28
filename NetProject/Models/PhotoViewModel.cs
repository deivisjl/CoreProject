using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace NetProject.Models
{
    public class PhotoViewModel
    {
        [Required]
        public int AlbumId { get; set; }
        [Required]
        public HttpPostedFileBase Photo { get; set; }
    }
}