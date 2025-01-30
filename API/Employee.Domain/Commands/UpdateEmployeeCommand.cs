using System.Net;
using System.Numerics;
using Employee.Domain.Commands.Contracts;
using Employee.Domain.Entities;
using Employee.Domain.Entities.ValueObjects;
using FluentValidation;

namespace Employee.Domain.Commands
{
    public sealed record UpdateEmployeeCommand : ICommand
    {
        public UpdateEmployeeCommand()
        {
                
        }

        public UpdateEmployeeCommand(string firstName, string lastName,  Guid id)
        {
            FirstName = firstName;
            LastName = lastName;
            Id = id;
        }

        public Guid Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }


        public List<string> Address { get; set; }

        public List<string> Phone { get; set; }
    }
}
