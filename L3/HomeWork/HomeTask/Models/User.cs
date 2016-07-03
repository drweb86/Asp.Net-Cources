using System.ComponentModel.DataAnnotations;

namespace HomeTask.Models
{
    public class User
    {
        [Required]
        public string Name { get; set; }
    }
}