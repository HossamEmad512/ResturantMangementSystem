using Resturant.Management.System.Core.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resturant.Management.System.Core.Specifications
{
    public class ResturantOwnerEmailSpecifications : BaseSpecifications<Resturants>
    {
        //get by owner email
        public ResturantOwnerEmailSpecifications(string email):base(R => R.OwnerEmail == email)
        {
          
        }
    }
}
