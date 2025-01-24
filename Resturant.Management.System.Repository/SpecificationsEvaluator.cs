using Microsoft.EntityFrameworkCore;
using Resturant.Management.System.Core.Entites;
using Resturant.Management.System.Core.Specifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resturant.Management.System.Repository
{
    public static class SpecificationsEvaluator<T> where T : BaseEntity
    {

        public static IQueryable<T> GetQuery(IQueryable<T> inputQuery , ISpecifications<T> Spec)
        {
            var Query = inputQuery;
            if(Spec.Criteria is not null)
            {
                Query = Query.Where(Spec.Criteria);
            }
            if(Spec.Includes.Count()>0)
            {
                Query = Spec.Includes.Aggregate(Query , (CurrentQuery , IncludeExpression)=>CurrentQuery.Include(IncludeExpression));
            }

            return Query;
        }
    }
}
