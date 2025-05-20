using Microsoft.EntityFrameworkCore;
using Resturant.Management.System.Core.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Resturant.Management.System.Repository.Data
{
    public class ResturantManagementContext : DbContext
    {
        public ResturantManagementContext(DbContextOptions<ResturantManagementContext> options):base(options)
        {
            
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //apply all configurations
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Menue> Menues { get; set; }
        public DbSet<Resturants> Resturants { get; set; }

        public DbSet<Sales> Sales { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<CurrentDishe> CurrentDishes { get; set; }
        public DbSet<WorkEmployee> WorkEmployees { get; set; }
        public DbSet<Recommendation> Recommendations { get; set;}

    }
}
