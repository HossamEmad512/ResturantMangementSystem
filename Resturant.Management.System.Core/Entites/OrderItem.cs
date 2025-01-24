using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resturant.Management.System.Core.Entites
{
    public class OrderItem :BaseEntity
    {
        public MenueItem Item { get; set; }
        public int Quantity {  get; set; }
        
        public decimal GetPrice()
        {
            return Quantity * Item.Price;
        }
        public decimal GetCost()
        {
            return Quantity * Item.Cost;
        }
    }
}
