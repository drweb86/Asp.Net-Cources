using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SK.CW15.Dal;

namespace SK.CW15.Bl
{
    public class ShopService: IShopService
    {
        public IEnumerable<GoodViewModel> GetGoods()
        {
            using (var dbContext = new PriceDbEntities())
            {
                return dbContext.Goods
                    .ToArray()
                    .Select(item => new GoodViewModel {Good_UID = item.Good_UID, Price = item.Price, Title = item.Title})
                    .ToArray();
            }
        }
    }
}
