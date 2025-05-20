using Microsoft.EntityFrameworkCore;
using Resturant.Management.System.Core.Entites;
using Resturant.Management.System.Core.Repository;
using Resturant.Management.System.Core.Specifications;
using Resturant.Management.System.Repository.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resturant.Management.System.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        private readonly ResturantManagementContext _dbContext;

        public GenericRepository(ResturantManagementContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task AddAsync(T item)
        {
            await _dbContext.AddAsync(item);
            _dbContext.SaveChanges();
        }

        public void Delete(T item)
        {
            _dbContext.Remove(item);
            _dbContext.SaveChanges();

        }


        public void Update(T item)
        {
            _dbContext.Update(item);
            _dbContext.SaveChanges();

        }

        private IQueryable<T> ApplySpecifications(ISpecifications<T> Spec)
        {
            return SpecificationsEvaluator<T>.GetQuery(_dbContext.Set<T>(), Spec);
        }
        public async Task<IEnumerable<T>> GetAllWithSpecAsync(ISpecifications<T> Spec  )
        {
           
            return await ApplySpecifications(Spec).ToListAsync();
        }

        public async Task<T> GetByIdWithSpecAsync(ISpecifications<T> Spec)
        {
            return await ApplySpecifications(Spec).FirstOrDefaultAsync();

        }

        public async Task<T> GetById(int id)
        {
            return await _dbContext.Set<T>().Where(item=>item.Id == id).FirstOrDefaultAsync();
        }
    }
}
