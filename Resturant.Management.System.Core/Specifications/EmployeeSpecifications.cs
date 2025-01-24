using Resturant.Management.System.Core.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resturant.Management.System.Core.Specifications
{
    public class EmployeeSpecifications:BaseSpecifications<Employee>
    {
        public EmployeeSpecifications(int ResturantId) : base(E => ResturantId == E.ResturantId)
        {

        }
        public EmployeeSpecifications(string EmployeeEmail) : base(E => EmployeeEmail == E.Email)
        {

        }
    }
}
