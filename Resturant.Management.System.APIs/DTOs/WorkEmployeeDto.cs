using System.ComponentModel.DataAnnotations;

namespace Resturant.Management.System.APIs.DTOs
{
    public class WorkEmployeeDto
    {
        public int ResturantId { get; set; }
        public decimal Salary { get; set; }
        public string Name { get; set; }

        [Phone]
        public string Phone { get; set; }
    }
}
