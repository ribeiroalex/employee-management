using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace Employee.Domain.Entities.Validators
{
    public class EmployeeValidator : AbstractValidator<Employee>
    {
        public EmployeeValidator()
        {
            RuleFor(employee => employee.FirstName).NotEmpty().Length(3, 50);
            RuleFor(employee => employee.LastName).NotEmpty().Length(3, 50);
            RuleFor(employee => employee.DocumentNumber).NotEmpty().Length(11);
            RuleFor(employee => employee.Password).NotEmpty().Length(6, 20)
                .Matches(@"^(?=.*[A-Z])(?=.*[a-z])(?=.*\d)(?=.*[\W_])[A-Za-z\d\W_]{12,}$")
                .WithMessage("Password must have at least 12 characters, one uppercase letter, one lowercase letter, one number and one special character and no spaces.");

            RuleForEach(employee => employee.Addresses).SetValidator(new AddressValidator());
        }
    }
}
