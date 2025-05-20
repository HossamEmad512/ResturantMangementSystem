using Resturant.Management.System.Core.Entites;
using Resturant.Management.System.Core.Specifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resturant.Management.System.Core.Repository
{
    public interface IGenericRepository<T> where T : BaseEntity
    {
        Task AddAsync(T item);
        void Update(T item);
        void Delete(T item);

        Task<IEnumerable<T>> GetAllWithSpecAsync(ISpecifications<T> Spec );
        Task<T> GetByIdWithSpecAsync(ISpecifications<T> Spec);
        Task<T> GetById(int id);
    }
}
