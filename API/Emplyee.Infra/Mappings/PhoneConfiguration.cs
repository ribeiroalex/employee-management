using Employee.Domain.Entities.ValueObjects;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emplyee.Infra.Mappings
{
    public class PhoneConfiguration : IEntityTypeConfiguration<Phone>
    {
        public void Configure(EntityTypeBuilder<Phone> builder)
        {
            builder.HasKey(pn => new { pn.PersonId, pn.PhoneNumber });

            builder.HasOne(pn => pn.Person)
                .WithMany(p => p.Phones)
                .HasForeignKey(pn => pn.PersonId);
        }
    }
}
