using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace DM2.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext() : base("DefaultConnection")
        {
                Database.SetInitializer<ApplicationDbContext>(new CreateDatabaseIfNotExists<ApplicationDbContext>());
        }

        public DbSet<Articles> Articles { get; set; }
        public DbSet<Users> Users { get; set; }
        public DbSet<Sections> Sections { get; set; }
        public DbSet<Tags> Tags { get; set; }
        public DbSet<ArticulosTag> ArticulosTags { get; set; }

    }
}