using Resturant.Management.System.Core.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resturant.Management.System.Core.Specifications
{
    public class EmployeeDeleteSpecifications : BaseSpecifications<Employee>
    {
        public EmployeeDeleteSpecifications(string EmployeeEmail):base(Employee=>EmployeeEmail==Employee.Email)
        {
            
        }
    }
}
