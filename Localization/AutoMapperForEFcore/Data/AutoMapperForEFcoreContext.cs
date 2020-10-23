using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AutoMapperForEFcore;
using AutoMapperForEFcore.Models;

namespace AutoMapperForEFcore.Data
{
    public class AutoMapperForEFcoreContext : DbContext
    {
        public AutoMapperForEFcoreContext (DbContextOptions<AutoMapperForEFcoreContext> options)
            : base(options)
        {
        }

        public DbSet<AppUser> AppUser { get; set; }
        public DbSet<Log> Log { get; set; }
    }
}
