using Resturant.Management.System.Core.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resturant.Management.System.Core.Specifications
{
    public class RecommendationSpecification:BaseSpecifications<Recommendation>
    {
        public RecommendationSpecification(int ResturantId) : base(R => ResturantId == R.ResturantId)
        {

        }
    }
}
