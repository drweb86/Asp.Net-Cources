using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ItAcademy.Galery.DalCF.Models;

namespace ItAcademy.Galery.DalCF
{
    public class GaleryContext: DbContext
    {
        public GaleryContext()
            : base("name=GaleryCF")
        {
        }

        public DbSet<Photo> Photos { get; set; }
    }
}
