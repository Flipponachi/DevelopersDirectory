using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using DevelopersDirectory.Models;

namespace DevelopersDirectory.DAL
{
    public class DirectoryContext : DbContext
    {
        public DirectoryContext() : base("DefaultConnection")
        {
            
        }
            
        public DbSet<Developer> Developers { get; set; }
        public DbSet<Category> Categories { get; set; }
    }
}