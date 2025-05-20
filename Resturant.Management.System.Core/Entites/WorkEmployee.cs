using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resturant.Management.System.Core.Entites
{
    public class WorkEmployee :BaseEntity
    {
        public int ResturantId { get; set; }
        public decimal Salary { get; set; }
        public string Name { get; set; }

        [Phone]
        public string Phone {  get; set; }
    }
}
