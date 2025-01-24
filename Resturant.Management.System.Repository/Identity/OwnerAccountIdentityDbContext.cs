using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Resturant.Management.System.Core.Entites.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resturant.Management.System.Repository.Identity
{
    public class OwnerAccountIdentityDbContext : IdentityDbContext<OwnerAccount>
    {
        public OwnerAccountIdentityDbContext(DbContextOptions<OwnerAccountIdentityDbContext> Options):base(Options)
        {
            
        }
    }
}
