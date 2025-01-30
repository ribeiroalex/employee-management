using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Employee.Domain.Entities;
using Emplyee.Infra.Mappings;
using Microsoft.EntityFrameworkCore;

namespace Emplyee.Infra.Contexts
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options)
            :base(options)
        {
                
        }

        public DbSet<Employee.Domain.Entities.Employee> Employees { get; set; }
        public DbSet<Person> People { get; set; }

        public DbSet<Employee.Domain.Entities.ValueObjects.Address> Addresses { get; set; }

        public DbSet<Employee.Domain.Entities.ValueObjects.Phone> Phones { get; set; }
        public DbSet<Employee.Domain.Entities.RolePermission> RolePermissions{ get; set; }

        public DbSet<Role> Roles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new EmployeeConfiguration());
            modelBuilder.ApplyConfiguration(new RoleConfiguration());
            modelBuilder.ApplyConfiguration(new PersonConfiguration());
            modelBuilder.ApplyConfiguration(new PhoneConfiguration());
            modelBuilder.ApplyConfiguration(new AddressConfiguration());
            modelBuilder.ApplyConfiguration(new RolePermissionConfiguration());
            base.OnModelCreating(modelBuilder);
        }
    }
}
