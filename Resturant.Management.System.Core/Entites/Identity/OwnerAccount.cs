using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resturant.Management.System.Core.Entites.Identity
{
    public class OwnerAccount :IdentityUser
    { 
        public string DisplayName { get; set; }
        public string GetRole()
        {
            return "Owner";
        }
    }
}
