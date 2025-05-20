using Resturant.Management.System.Core.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resturant.Management.System.Core.Repository
{
    public interface ICurrentDisheRepository
    {
        Task<IEnumerable<CurrentDishe>> GetAllAsync(int ResturantId);
    }
}
