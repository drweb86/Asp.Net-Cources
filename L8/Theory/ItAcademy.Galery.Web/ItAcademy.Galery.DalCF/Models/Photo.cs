using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ItAcademy.Galery.DalCF.Models
{


    public class Photo
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }






        public string Description { get; set; }
        //after that add-migration, name: added_column_description, after that update-database
    }
}
