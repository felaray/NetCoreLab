using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;

namespace ExceptionLab.Models
{
    /// <summary>
    /// EF Core 5 : Index key
    /// </summary>
    [Index(nameof(Mobile), IsUnique = true)]
    public class AppUser
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Mobile { get; set; }

    }
}
