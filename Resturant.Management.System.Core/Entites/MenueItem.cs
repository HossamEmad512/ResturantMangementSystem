using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resturant.Management.System.Core.Entites
{
    public class MenueItem:BaseEntity
    {
        
        public string Name {  get; set; }
        public decimal Cost { get; set; }
        public decimal Price { get; set; }
        //public string Category { get; set; }

    }
}
