using Resturant.Management.System.Core.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resturant.Management.System.Core.Specifications
{
    public class OrderSpecifications : BaseSpecifications<Order>
    {
        public OrderSpecifications(int ResturantId) : base(O => ResturantId == O.ResturantId)
        {
            this.Includes.Add(O => O.OrderItems);
            this.Includes.Add(O => O.OrderItems);
            
        }
    }
}
