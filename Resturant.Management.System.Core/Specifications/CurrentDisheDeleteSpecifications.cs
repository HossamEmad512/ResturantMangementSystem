using Resturant.Management.System.Core.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resturant.Management.System.Core.Specifications
{
    public class CurrentDisheDeleteSpecifications : BaseSpecifications<CurrentDishe>
    {
        public CurrentDisheDeleteSpecifications(int CurrentDisheId) : base(O => CurrentDisheId == O.Id)
        {
            this.Includes.Add(O => O.OrderItems);

        }
    }
}
