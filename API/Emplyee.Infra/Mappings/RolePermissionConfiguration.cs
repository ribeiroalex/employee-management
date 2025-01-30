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
    public class RolePermissionConfiguration : IEntityTypeConfiguration<RolePermission>
    {
        public void Configure(EntityTypeBuilder<RolePermission> builder)
        {
            builder.HasKey(rp => new { rp.RoleId, rp.CanCreateRoleId });

            builder.HasOne(rp => rp.Role)
                   .WithMany(r => r.RolePermission)
                   .HasForeignKey(rp => rp.RoleId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(rp => rp.CanCreateRole)
                   .WithMany()
                   .HasForeignKey(rp => rp.CanCreateRoleId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.Property(rp => rp.RoleId).IsRequired();
            builder.Property(rp => rp.CanCreateRoleId).IsRequired();
        }
    }
}
