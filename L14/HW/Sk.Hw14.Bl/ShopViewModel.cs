using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sk.Hw14.Dal;

namespace Sk.Hw14.Bl
{
    public class ShopViewModel
    {
        public int Shop_UID { get; set; }
        public string Name { get; set; }
        public TimeSpan OpensAt { get; set; }
        public TimeSpan ClosesAt { get; set; }
        public string Description { get; set; }

        public ShopViewModel()
        {
        }

        internal ShopViewModel(Shop shop)
        {
            Shop_UID = shop.Shop_UID;
            Name = shop.Name;
            OpensAt = shop.OpensAt;
            ClosesAt = shop.ClosesAt;
            Description = shop.Description;
        }
    }
}
