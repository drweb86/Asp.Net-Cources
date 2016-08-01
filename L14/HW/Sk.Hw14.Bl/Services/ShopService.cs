using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sk.Hw14.Dal;

namespace Sk.Hw14.Bl.Services
{
    public class ShopService
    {
        public IEnumerable<ShopViewModel> GetShops()
        {
            using (var dbContext = new ShopsDatabaseEntities())
            {
                return dbContext.Shops
                    .ToArray()
                    .Select(dbShop => new ShopViewModel(dbShop))
                    .ToArray();
            }
        }

        public ShopViewModel GetShop(int id)
        {
            using (var dbContext = new ShopsDatabaseEntities())
            {
                return new ShopViewModel(dbContext.Shops
                    .First(item=>item.Shop_UID == id));
            }
        }
    }
}
