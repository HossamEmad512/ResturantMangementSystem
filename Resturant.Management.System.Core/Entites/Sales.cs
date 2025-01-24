using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resturant.Management.System.Core.Entites
{
    public class Sales:BaseEntity
    {
        public int ResturantId {  get; set; }
        public ICollection<Order> Orders { get; set; } = new List<Order>();
        public decimal GetTotalCost()
        {
            decimal totalCost = 0;
            foreach (var order in Orders)
            {
                totalCost += order.GetTotalCost();
            }
            return totalCost;
        }
        public decimal GetTotalPrice()
        {
            decimal totalPrice = 0;
            foreach (var order in Orders)
            {
                totalPrice += order.GetTotalPrice();
            }
            return totalPrice;
        }
        public decimal GetTotalProfit()
        {
            decimal totalProfit = GetTotalPrice() - GetTotalCost();
            return totalProfit;
        }

    }
}
