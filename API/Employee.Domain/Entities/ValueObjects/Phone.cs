using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee.Domain.Entities.ValueObjects
{
    public class Phone (Guid personId, string PhoneNumber)
    {
        public Guid PersonId { get; private set; } = personId;

        public string PhoneNumber { get; private set; } = PhoneNumber;

        public Person? Person { get; private set; }
    }
}
