using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CW1.Models
{
    public class Factorial
    {
        [Range(1,10000, ErrorMessage = "Expected 1..10000")]
        [Required]
        public int Number { get; set; }

        //? is it a good way
        public int Result { get; set; }
    }
}