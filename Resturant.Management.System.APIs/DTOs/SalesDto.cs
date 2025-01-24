using Resturant.Management.System.Core.Entites;

namespace Resturant.Management.System.APIs.DTOs
{
    public class SalesDto
    {
        public int ResturantId { get; set; }
        public ICollection<OrderDto> Orders { get; set; } = new List<OrderDto>();

        public decimal TotalCost {  get; set; }
        public decimal TotalPrice { get; set; }

        public decimal TotalProfit {  get; set; }
    }
}
