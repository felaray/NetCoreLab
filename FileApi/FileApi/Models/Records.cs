using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FileApi.Models
{
    public class Records
    {
        public Guid Id { get; set; }
        public string UserName { get; set; }
        public DateTime UploadDateTime { get; set; }
    }
}
