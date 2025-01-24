using Resturant.Management.System.Core.Entites;

namespace Resturant.Management.System.APIs.DTOs
{
    public class MenueDto
    {
        public int ResturantId { get; set; }
       

        public ICollection<MenueItemDto> menueItems { get; set; } = new List<MenueItemDto>();
    }
}
