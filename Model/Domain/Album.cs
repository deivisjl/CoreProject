using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Domain
{
    public class Album
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string PhotoLink { get; set; }
        public DateTime CreatedAt { get; set; }

        public ICollection<Photo> Photo { get; set; }
    }
}
