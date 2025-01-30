using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Employee.Domain.Commands;
using Employee.Domain.Commands.Contracts;
using Employee.Domain.Entities;
using Employee.Domain.Handlers.Contracts;
using Employee.Domain.Repositories;
using Employee.Domain.Services;
using FluentValidation;

namespace Employee.Domain.Handlers
{
    public class EmployeeHandler : ICommandHandler<CreateEmployeeCommand>, ICommandHandler<UpdateEmployeeCommand>, ICommandHandler<DeleteEmployeeCommandById>
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly RolePermissionService _rolePermissionService;
        private readonly IValidator<Entities.Employee> _validator;
        private readonly IMapper _mapper;

        public EmployeeHandler(IEmployeeRepository employeeRepository, RolePermissionService rolePermissionService, IValidator<Entities.Employee> validator, IMapper mapper)
        {
            _employeeRepository = employeeRepository;
            _rolePermissionService = rolePermissionService;
            _validator = validator;
            _mapper = mapper;
        }
        private async Task<GenericCommandResult> ValidateCreatorAndRole(CreateEmployeeCommand command)
        {
            var creator = await _employeeRepository.GetByIdAsync(command.CreatedById);
            if (creator == null) return new GenericCommandResult(false, "Creator not found", $"CreatorId: {command.CreatedById}");

            var role = await _employeeRepository.GetRoleByIdAsync(command.RoleId);
            if (role == null) return new GenericCommandResult(false, "Role not found", $"RoleId: {command.RoleId}");

            var hasPermission = await _rolePermissionService.CanCreateRoleAsync(creator.Roles, role);
            if (!hasPermission) return new GenericCommandResult(false, "You do not have permission to create this role.", $"Missing Role Permission: {role.RoleName}");

            return new GenericCommandResult(true, "Validation successful", null);
        }

        public async Task<ICommandResult> Handle(CreateEmployeeCommand command)
        {
            var newEmployee = _mapper.Map<CreateEmployeeCommand, Entities.Employee>(command);
            var validationResult = _validator.Validate(newEmployee);
            if (!validationResult.IsValid)
                return new GenericCommandResult(false, "An error occured while creating new employee!", string.Join(",", validationResult.Errors));

            var validationCommandResult = await ValidateCreatorAndRole(command);
            if (!validationCommandResult.Sucesss)
                return validationCommandResult;

            var manager = command.ManagerId.HasValue ? await _employeeRepository.GetByIdAsync(command.ManagerId.Value) : null;
            if (manager == null) return new GenericCommandResult(false, "Manager not found", $"ManagerId: {command.ManagerId}");

            //this should be done via a service after the employee is created. but for the simplicity of this demo I will keep it.
            newEmployee.SetManager(manager);

            return new GenericCommandResult(true, "Employee created with success!", newEmployee);
        }

        public async Task<ICommandResult> Handle(UpdateEmployeeCommand command)
        {
            var employee = await _employeeRepository.GetByIdAsync(command.Id);
            if(employee == null)
                return new GenericCommandResult(false, "Employee not found!", $"Id:{command.Id}");
            

            var validationResult = _validator.Validate(employee);
            if (!validationResult.IsValid)
                return new GenericCommandResult(false, "An error occured while updating employee!", string.Join(",", validationResult.Errors));

            var resut = _employeeRepository.Update(employee);
            return new GenericCommandResult(true, "Employee update with success!", resut);
        }

        public async Task<ICommandResult> Handle(DeleteEmployeeCommandById command)
        {
            var employee = await _employeeRepository.GetByIdAsync(command.Id);

            if (employee == null)
            {
                return new GenericCommandResult(false, $"Error Employee {command.Id} not found!", "Invalid employee");
            }

            var resut = _employeeRepository.Delete(employee);

            if(resut)
                return new GenericCommandResult(true, "Employee delete with success!", resut);
            else
                return new GenericCommandResult(false, "Error delete update employee!", resut);
        }
    }
}
