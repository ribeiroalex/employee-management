
using Employee.Domain.Commands.Contracts;

namespace Employee.Domain.Commands
{
    public sealed record DeleteEmployeeCommandById : ICommand
    {
        public DeleteEmployeeCommandById(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }

    }
}
