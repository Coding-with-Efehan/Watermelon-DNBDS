using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Watermelon.Data.Models;

namespace Watermelon.Data.Context
{
    public class WatermelonDbContext : DbContext
    {
        public WatermelonDbContext(DbContextOptions options)
            : base(options)
        {
        }

        public DbSet<Guild> Guilds { get; set; }
    }
}
