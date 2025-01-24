using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Resturant.Management.System.Core.Entites
{
    public class Order : BaseEntity
    {
        public int ResturantId { get; set; }
        public DateTimeOffset DateOfCreation { get; set; } = DateTimeOffset.Now; 
        public ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
        public decimal GetTotalPrice() 
        {
            decimal sum = 0;
         foreach (var item in OrderItems)
            {
                sum += item.GetPrice();
            }
         return sum;
        }
        public decimal GetTotalCost()
        {
            decimal sum = 0;
            foreach (var item in OrderItems)
            {
                sum += item.GetCost();
            }
            return sum;
        }

    }
}
