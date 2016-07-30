using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ItAcademy.Galery.DalCF.Models;

namespace ItAcademy.Galery.DalCF.Migrations
{
    class Configuration: DbMigrationsConfiguration<GaleryContext>
    {
        protected override void Seed(GaleryContext context)
        {
            base.Seed(context);

            //TODO: add sdome test data to DB here.
            context.Photos.Add(new Photo() {Name = "Catty", Url = "http://nn.by/?c=ar&i=173451"});
            context.Photos.Add(new Photo() { Name = "Pussy", Url = "http://nn.by/img/w652d4/photos/z_2016_07/griezmann1_160711-rlvgf.jpg" });

        }
    }
}
