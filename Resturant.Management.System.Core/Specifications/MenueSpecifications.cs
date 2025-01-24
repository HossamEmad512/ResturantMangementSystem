using Resturant.Management.System.Core.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resturant.Management.System.Core.Specifications
{
    public class MenueSpecifications :BaseSpecifications<Menue>
    {
        public MenueSpecifications(int ResturantId) : base(M => ResturantId == M.ResturantId)
        {
            this.Includes.Add(M => M.menueItems);
        }
    }
}
