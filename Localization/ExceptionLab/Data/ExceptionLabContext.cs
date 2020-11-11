using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ExceptionLab.Models;

namespace ExceptionLab.Data
{
    public class ExceptionLabContext : DbContext
    {
        public ExceptionLabContext (DbContextOptions<ExceptionLabContext> options)
            : base(options)
        {
        }

        public DbSet<ExceptionLab.Models.AppUser> AppUser { get; set; }
    }
}
