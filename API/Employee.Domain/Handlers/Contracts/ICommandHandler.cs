using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Employee.Domain.Commands.Contracts;

namespace Employee.Domain.Handlers.Contracts
{
    public interface ICommandHandler <T> where T: ICommand
    {
        Task<ICommandResult> Handle(T command);
    }
}
