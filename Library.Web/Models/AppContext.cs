using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Library.Web.Models
{
    public class AppContext:DbContext 
    {
        public AppContext()
        {
            
        }
        public DbSet<Book> Books { get; set; }
    }
}