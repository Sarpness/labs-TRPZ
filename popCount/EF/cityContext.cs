using Microsoft.EntityFrameworkCore;
using popCount.entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace popCount.EF
{
    public class cityContext : DbContext
    {
        public DbSet<city> cityId { get; set; }
        public DbSet<city> cityName { get; set; }
        public DbSet<city> count { get; set; }
        public DbSet<city> updated_at { get; set; }

        public cityContext(DbContextOptions options) : base(options)
        {

        }
    }
}
