using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Domain
{
    public class Photo
    {
        public int Id { get; set; }
        public string PhotoLink { get; set; }
        public DateTime CreatedAt { get; set; }

        [ForeignKey("Album")]
        public int AlbumId { get; set; }

        public Album Album { get; set; }
    }
}
