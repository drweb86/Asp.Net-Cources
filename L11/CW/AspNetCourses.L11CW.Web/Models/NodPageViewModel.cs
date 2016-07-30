using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AspNetCourses.L9.Web.Models
{
    public class NodPageViewModel
    {
        [Required]
        public int A { get; set; }

        [Required]
        public int B { get; set; }
    }
}