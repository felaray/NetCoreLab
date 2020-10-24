using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AutoMapperForEFcore.Models
{
    public class AppUser : IdentityUser<int>
    {
        public List<Log> Logs { get; set; }
    }

    public class Log
    {
        public int Id { get; set; }
        public string Msg { get; set; }
    }

    public class AppUserDTO
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public List<Log> Logs { get; set; }
    }
}
