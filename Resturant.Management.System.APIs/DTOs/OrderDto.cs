using Resturant.Management.System.Core.Entites;
using System.Diagnostics.CodeAnalysis;

namespace Resturant.Management.System.APIs.DTOs
{
    public class OrderDto
    {

        public int ResturantId { get; set; }
        public int TableNumber {  get; set; }
        [AllowNull]
        public string PhoneNumber { get; set; }
        public ICollection<OrderItemDto> OrderItems { get; set; } = new List<OrderItemDto>();
        public decimal GetTotalPrice()
        {
            decimal sum = 0;
            foreach (var item in this.OrderItems)
            {
                sum += item.GetPrice();
            }
            return sum;
        }

        public decimal TotalPrice { get; set; } = 0;
        public  decimal GetTotalCost()
        {
            decimal sum = 0;
            foreach (var item in this.OrderItems)
            {
                sum += item.GetCost();
            }
            return sum;
        }

        public decimal TotalCost { get; set; } = 0;
        public DateTimeOffset DateOfCreation { get; set; } = DateTimeOffset.Now;


    }
}
