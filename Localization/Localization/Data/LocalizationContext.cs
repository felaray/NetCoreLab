using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Localization.Models;

namespace Localization.Data
{
    public class LocalizationContext : DbContext
    {
        public LocalizationContext (DbContextOptions<LocalizationContext> options)
            : base(options)
        {
        }

        public DbSet<AppUser> Test { get; set; }
    }
}
