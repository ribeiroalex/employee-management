using Employee.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emplyee.Infra.Mappings
{
    public class RoleConfiguration : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.ToTable("Role");

            builder.HasKey(x => x.RoleId);

            builder.Metadata.FindNavigation("Employee")?.SetPropertyAccessMode(PropertyAccessMode.Field);
            builder.Metadata.FindNavigation("RolePermission")?.SetPropertyAccessMode(PropertyAccessMode.Field);

            builder.HasMany(builder => builder.RolePermission)
                .WithOne()
                .HasForeignKey("RoleId")
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
