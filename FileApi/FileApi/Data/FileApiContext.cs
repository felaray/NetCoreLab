using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using FileApi.Models;

namespace FileApi.Data
{
    public class FileApiContext : DbContext
    {
        public FileApiContext (DbContextOptions<FileApiContext> options)
            : base(options)
        {
        }

        public DbSet<FileApi.Models.Records> Record { get; set; }

        public DbSet<FileApi.Models.Files> Files { get; set; }
    }
}
