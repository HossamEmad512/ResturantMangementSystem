using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resturant.Management.System.Core.Entites
{
    public class Menue :BaseEntity
    {
        public int ResturantId {  get; set; }
        public DateTimeOffset DateOfCreation { get; set; } = DateTimeOffset.Now;

        public ICollection<MenueItem> menueItems { get; set; } = new List<MenueItem>();
    }
}
