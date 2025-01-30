using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee.Domain.Entities.ValueObjects
{
    public class Address(Guid personId,string addressLine)
    {
        public Guid PersonId { get; private set; } = personId;
        public string AddressLine { get; private set; } = addressLine;

        public Person? Person { get; private set; }

    }
}
