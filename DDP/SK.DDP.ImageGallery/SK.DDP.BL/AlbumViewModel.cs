using System;
using System.ComponentModel.DataAnnotations;

namespace SK.DDP.BL
{
    public class AlbumViewModel
    {
        public AlbumViewModel()
        {
            User_UID = Guid.Empty;
        }

        public int Album_UID { get; set; }
        public System.Guid User_UID { get; set; }

        [Required]
        public string Name { get; set; }
    }
}
