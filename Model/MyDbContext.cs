using Microsoft.AspNet.Identity.EntityFramework;
using Model.Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class MyDbContext : IdentityDbContext
    {
        public MyDbContext(): base("NewContext") {

        }

        public DbSet<Album> Album { get; set; }
        public DbSet<Photo> Photo { get; set; }

    }
}
