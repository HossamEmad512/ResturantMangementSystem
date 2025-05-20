namespace Resturant.Management.System.APIs.DTOs
{
    public class RecommendationDto
    {
        public int ResturantId { get; set; }
        public string Category { get; set; }
        public string Name { get; set; }
        public string PrepMethod { get; set; }
        public string Country { get; set; }
        public decimal Cost { get; set; }
        public decimal Price { get; set; }
        public decimal Rating { get; set; }
    }
}
