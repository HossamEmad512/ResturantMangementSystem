using Resturant.Management.System.Core.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resturant.Management.System.Core.Specifications
{
    public class ResturantSpecification :BaseSpecifications<Resturants>
    {
        //get by owner id
        public ResturantSpecification(int id) : base(R => R.Id == id)
        {

        }
    }
}
