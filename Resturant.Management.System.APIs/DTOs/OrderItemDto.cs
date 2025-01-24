using Resturant.Management.System.Core.Entites;

namespace Resturant.Management.System.APIs.DTOs
{
    public class OrderItemDto
    {

        public MenueItemDto Item { get; set; }
        public int Quantity { get; set; }

        public decimal GetPrice()
        {
            return this.Quantity * this.Item.Price;
        }
        public decimal Price { get; set; } = 0;
        public decimal GetCost()
        {
            return this.Quantity * this.Item.Cost;
        }
        public decimal Cost { get; set; } = 0;
    }
}