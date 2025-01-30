using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Employee.Domain.Entities.ValueObjects;
using FluentValidation;

namespace Employee.Domain.Entities.Validators
{
    public class AddressValidator : AbstractValidator<Address>
    {
        public AddressValidator()
        {
            RuleFor(address => address.AddressLine).NotNull().NotEmpty();
        }
    }
}
