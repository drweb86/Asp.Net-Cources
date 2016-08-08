using System.Collections;
using System.Collections.Generic;

namespace SK.CW15.Bl
{
    public interface IShopService
    {
        IEnumerable<GoodViewModel> GetGoods();
    }
}