using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resturant.Management.System.Core.Entites
{
    public class CurrentDishe :BaseEntity
    {
        public int ResturantId { get; set; }
        public DateTimeOffset DateOfCreation { get; set; } = DateTimeOffset.Now;
        public ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
        [AllowNull]
        public int TableNumber { get; set; }
        [AllowNull]
        public string PhoneNumber { get; set; }
        [AllowNull]
        public string Status { get; set; }
    }
}
