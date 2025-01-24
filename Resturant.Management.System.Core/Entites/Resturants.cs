using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resturant.Management.System.Core.Entites
{
    public class Resturants : BaseEntity
    {
        public string ResturantName {  get; set; }
        public DateTimeOffset DateOfCreation { get; set; } = DateTimeOffset.Now;

        public string OwnerEmail {  get; set; }
        public Menue? Menue { get; set; }
        public Sales? Sales { get; set; }
    }
}
