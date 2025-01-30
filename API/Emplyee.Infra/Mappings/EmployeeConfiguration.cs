using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azure;
using Employee.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Metadata.Conventions.Infrastructure;

namespace Emplyee.Infra.Mappings
{
    public class EmployeeConfiguration : IEntityTypeConfiguration<Employee.Domain.Entities.Employee>
    {
        public void Configure(EntityTypeBuilder<Employee.Domain.Entities.Employee> builder)
        {
            builder.HasBaseType<Person>();
            builder.ToTable("Employee");

            builder.HasOne(x => x.Manager)
                .WithMany(x =>x .EmployessList)
                .HasForeignKey(x => x.ManagerId)
                .IsRequired(false);



            builder.HasMany(builder => builder.Phones)
                .WithOne()
                .HasForeignKey("EmployeeId")
                .OnDelete(DeleteBehavior.Cascade);

            builder.Metadata.FindNavigation("Phones")?.SetPropertyAccessMode(PropertyAccessMode.Field);

            builder.HasMany(builder => builder.Addresses)
                .WithOne()
                .HasForeignKey("EmployeeId")
                .OnDelete(DeleteBehavior.Cascade);

            builder.Metadata.FindNavigation("Addresses")?.SetPropertyAccessMode(PropertyAccessMode.Field);
            builder.Metadata.FindNavigation("Roles")?.SetPropertyAccessMode(PropertyAccessMode.Field);

        }
    }
}
