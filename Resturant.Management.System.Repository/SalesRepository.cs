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
    public class SalesRepository : ISalesRepository 
    {
        private readonly ResturantManagementContext _dbContext;

        public SalesRepository(ResturantManagementContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Sales> GetSaleByResturantId(int ResturantId)
        {
            // return await _dbContext.Orders.Include(O => O.OrderItems).ThenInclude(I => I.Item).Where(O => ResturantId == O.ResturantId).ToListAsync();
            return await  _dbContext.Sales.Include(S => S.Orders).ThenInclude(O => O.OrderItems).ThenInclude(I => I.Item).Where(s => ResturantId == s.ResturantId).FirstOrDefaultAsync();
        }
    }
}
