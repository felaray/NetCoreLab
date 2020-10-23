using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Localization.Models
{
    public class TestRequest
    {
        [Required(ErrorMessage = "miss")]
        [Display(Name = "miss")]
        public string FieldA { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="LocalizedIdentityErrorDescriber"/>
        /// </summary>
        public string FieldB { get; set; }
    }
}
