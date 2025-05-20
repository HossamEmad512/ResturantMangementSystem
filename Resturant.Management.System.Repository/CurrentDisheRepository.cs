using Microsoft.EntityFrameworkCore;
using Resturant.Management.System.Core.Entites;
using Resturant.Management.System.Core.Repository;
using Resturant.Management.System.Repository.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resturant.Management.System.Repository
{
    public class CurrentDisheRepository : ICurrentDisheRepository
    {

        private readonly ResturantManagementContext _dbContext;

        public CurrentDisheRepository(ResturantManagementContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<CurrentDishe>> GetAllAsync(int ResturantId)
        {
            return await _dbContext.CurrentDishes.Include(O => O.OrderItems).ThenInclude(I => I.Item).Where(O => ResturantId == O.ResturantId).ToListAsync();
        }
    }
}
