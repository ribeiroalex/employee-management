using System.Net;
using System.Numerics;
using Employee.Domain.Commands.Contracts;
using Employee.Domain.Entities;
using Employee.Domain.Entities.ValueObjects;
using FluentValidation;

namespace Employee.Domain.Commands
{
    public sealed record CreateEmployeeCommand : ICommand
    {
        public CreateEmployeeCommand()
        {
                
        }

        public CreateEmployeeCommand(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;

        }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string DocumentNumber { get; set; }

        public string Password { get; set; }

        public Guid CreatedById { get; set; }

        public Guid? ManagerId { get; set; }

        public int RoleId { get; set; }

        public List<string> Phone { get; set; }

        public List<string> Address { get; set; }

    }
}
