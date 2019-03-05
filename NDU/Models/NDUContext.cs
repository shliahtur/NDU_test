using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NDU.Models
{
    public class NDUContext : DbContext
    {
     
        public NDUContext(DbContextOptions<NDUContext> options)
        : base(options)
        { }

        public DbSet<Document> Documents { get; set; }

    }
}
