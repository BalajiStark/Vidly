using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    public class MyDbContext : DbContext
    {
        public DbSet<Customers> customers { get; set; }
        public DbSet<Genre> genres { get; set; }
        public MyDbContext()
        {
        }
    }
}