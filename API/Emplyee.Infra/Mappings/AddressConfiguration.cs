using Employee.Domain.Entities.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Emplyee.Infra.Mappings
{
    public class AddressConfiguration : IEntityTypeConfiguration<Address>
    {
        public void Configure(EntityTypeBuilder<Address> builder)
        {
            builder.HasKey(pn => new { pn.PersonId, pn.AddressLine });

            builder.HasOne(pn => pn.Person)  
                .WithMany(p => p.Addresses)  
                .HasForeignKey(pn => pn.PersonId);
        }
    }
}
