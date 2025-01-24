using Resturant.Management.System.Core.Entites;
using Resturant.Management.System.Core.Specifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resturant.Management.System.Core.Repository
{
    public interface IOrderRepository
    {
        Task<IEnumerable<Order>> GetAllAsync(int ResturantId);
    }
}
