using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resturant.Management.System.Core.Entites
{
    public class Employee : BaseEntity
    {
        [EmailAddress]
        [Key]
        public string Email {  get; set; }
        [DataType(DataType.Password)]
        public string Password {  get; set; }
        public int ResturantId {  get; set; }
        public decimal Salary {  get; set; }
        public string Name { get; set; }
        [AllowNull]
        public string Position { get; set; }

        public string GetRole()
        {
            return "Employee";
        }
    }
}
