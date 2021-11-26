using Microsoft.EntityFrameworkCore;
using popCount.entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace popCount.EF
{
    public class taskContext : DbContext
    {
        public DbSet<task> idCity { get; set; }
        public DbSet<task> status { get; set; }
        public DbSet<task> created_at { get; set; }

        public taskContext(DbContextOptions options) : base(options)
        {

        }
    }
}
