using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Employee.Domain.Commands.Contracts;

namespace Employee.Domain.Commands
{
    public sealed record GenericCommandResult : ICommandResult
    {
        public GenericCommandResult()
        {
                
        }
        public GenericCommandResult(bool sucesss, string message, object data)
        {
            Sucesss = sucesss;
            Message = message;
            Data = data;
        }

        public bool Sucesss { get; set; }
        public string Message { get; set; }

        public object Data { get; set; }
    }
}
