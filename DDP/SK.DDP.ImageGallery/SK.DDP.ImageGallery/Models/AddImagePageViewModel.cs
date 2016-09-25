using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SK.DDP.ImageGallery.Models
{
    public class AddImagePageViewModel
    {
        [Required]
        public int Album { get; set; }

        [Required]
        public HttpPostedFileBase Image { get; set; }
    }
}