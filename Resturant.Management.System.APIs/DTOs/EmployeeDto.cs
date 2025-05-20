using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace Resturant.Management.System.APIs.DTOs
{
    public class EmployeeDto
    {

        [AllowNull]
        public string Position { get; set; }
        public string Name { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        public int ResturantId { get; set; }

        [DataType(DataType.Password)]
        public string Password { get; set; }
        public decimal Salary { get; set; }

        public string Role {  get; set; }
    }
}
