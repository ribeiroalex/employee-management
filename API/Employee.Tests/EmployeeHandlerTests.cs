using AutoMapper;
using Employee.Domain.Commands;
using Employee.Domain.Entities;
using Employee.Domain.Handlers;
using Employee.Domain.Repositories;
using Employee.Domain.Services;
using FluentValidation;
using Moq;

namespace Employee.Tests.Handlers
{
    [TestClass]
    public class EmployeeHandlerTests
    {
        private Mock<IEmployeeRepository> _employeeRepositoryMock;
        private Mock<IValidator<Domain.Entities.Employee>> _validatorMock;
        private Mock<IMapper> _mapperMock;
        private Mock<RolePermissionService> _rolePermissionServiceMock;
        private EmployeeHandler _employeeHandler;

        [TestInitialize]
        public void Setup()
        {
            _employeeRepositoryMock = new Mock<IEmployeeRepository>();
            _validatorMock = new Mock<IValidator<Domain.Entities.Employee>>();
            _mapperMock = new Mock<IMapper>();
            _rolePermissionServiceMock = new Mock<RolePermissionService>(MockBehavior.Strict, new Mock<IRolePermissionRepository>().Object);
            _employeeHandler = new EmployeeHandler(_employeeRepositoryMock.Object, _rolePermissionServiceMock.Object, _validatorMock.Object, _mapperMock.Object);
        }

        [TestMethod]
        public async Task Handle_CreateEmployeeCommand_ShouldReturnSuccessResult_WhenValid()
        {
            // Arrange
            var command = new CreateEmployeeCommand
            {
                FirstName = "John",
                LastName = "Doe",
                CreatedById = Guid.NewGuid(),
                RoleId = 1,
                ManagerId = Guid.NewGuid()
            };

            var employee = new Domain.Entities.Employee("John", "Doe");
            var creator = new Domain.Entities.Employee("Admin", "User");
            var role = new Role(1, "Manager");

            _mapperMock.Setup(m => m.Map<CreateEmployeeCommand, Domain.Entities.Employee>(command)).Returns(employee);
            _validatorMock.Setup(v => v.Validate(employee)).Returns(new FluentValidation.Results.ValidationResult());
            _employeeRepositoryMock.Setup(r => r.GetByIdAsync(command.CreatedById)).ReturnsAsync(creator);
            _employeeRepositoryMock.Setup(r => r.GetRoleByIdAsync(command.RoleId)).ReturnsAsync(role);
            _employeeRepositoryMock.Setup(r => r.GetByIdAsync(command.ManagerId.Value)).ReturnsAsync(new Domain.Entities.Employee("Manager", "User"));
            _rolePermissionServiceMock.Setup(r => r.CanCreateRoleAsync(It.IsAny<IEnumerable<Role>>(), It.IsAny<Role>())).ReturnsAsync(true);

            // Act
            var result = (await _employeeHandler.Handle(command)) as GenericCommandResult;

            // Assert
            Assert.IsTrue(result.Sucesss);
            Assert.AreEqual("Employee created with success!", result.Message);
        }

        [TestMethod]
        public async Task Handle_CreateEmployeeCommand_ShouldReturnErrorResult_WhenValidationFails()
        {
            // Arrange
            var command = new CreateEmployeeCommand
            {
                FirstName = "John",
                LastName = "Doe",
                CreatedById = Guid.NewGuid(),
                RoleId = 1,
                ManagerId = Guid.NewGuid()
            };

            var employee = new Domain.Entities.Employee("John", "Doe");
            var validationResult = new FluentValidation.Results.ValidationResult(new List<FluentValidation.Results.ValidationFailure>
            {
                new FluentValidation.Results.ValidationFailure("FirstName", "First name is required")
            });

            _mapperMock.Setup(m => m.Map<CreateEmployeeCommand, Domain.Entities.Employee>(command)).Returns(employee);
            _validatorMock.Setup(v => v.Validate(employee)).Returns(validationResult);

            // Act
            var result = (await _employeeHandler.Handle(command)) as GenericCommandResult;

            // Assert
            Assert.IsFalse(result.Sucesss);
            Assert.AreEqual("An error occured while creating new employee!", result.Message);
        }

        [TestMethod]
        public async Task Handle_CreateEmployeeCommand_ShouldReturnErrorResult_WhenCreatorNotFound()
        {
            // Arrange
            var command = new CreateEmployeeCommand
            {
                FirstName = "John",
                LastName = "Doe",
                CreatedById = Guid.NewGuid(),
                RoleId = 1,
                ManagerId = Guid.NewGuid()
            };

            var employee = new Domain.Entities.Employee("John", "Doe");

            _mapperMock.Setup(m => m.Map<CreateEmployeeCommand, Domain.Entities.Employee>(command)).Returns(employee);
            _validatorMock.Setup(v => v.Validate(employee)).Returns(new FluentValidation.Results.ValidationResult());
            _employeeRepositoryMock.Setup(r => r.GetByIdAsync(command.CreatedById)).ReturnsAsync((Domain.Entities.Employee)null);

            // Act
            var result = (await _employeeHandler.Handle(command)) as GenericCommandResult;

            // Assert
            Assert.IsFalse(result.Sucesss);
            Assert.AreEqual("Creator not found", result.Message);
        }

        [TestMethod]
        public async Task Handle_CreateEmployeeCommand_ShouldReturnErrorResult_WhenRoleNotFound()
        {
            // Arrange
            var command = new CreateEmployeeCommand
            {
                FirstName = "John",
                LastName = "Doe",
                CreatedById = Guid.NewGuid(),
                RoleId = 1,
                ManagerId = Guid.NewGuid()
            };

            var employee = new Domain.Entities.Employee("John", "Doe");
            var creator = new Domain.Entities.Employee("Admin", "User");

            _mapperMock.Setup(m => m.Map<CreateEmployeeCommand, Domain.Entities.Employee>(command)).Returns(employee);
            _validatorMock.Setup(v => v.Validate(employee)).Returns(new FluentValidation.Results.ValidationResult());
            _employeeRepositoryMock.Setup(r => r.GetByIdAsync(command.CreatedById)).ReturnsAsync(creator);
            _employeeRepositoryMock.Setup(r => r.GetRoleByIdAsync(command.RoleId)).ReturnsAsync((Role)null);

            // Act
            var result = (await _employeeHandler.Handle(command)) as GenericCommandResult;

            // Assert
            Assert.IsFalse(result.Sucesss);
            Assert.AreEqual("Role not found", result.Message);
        }

        [TestMethod]
        public async Task Handle_CreateEmployeeCommand_ShouldReturnErrorResult_WhenManagerNotFound()
        {
            // Arrange
            var command = new CreateEmployeeCommand
            {
                FirstName = "John",
                LastName = "Doe",
                CreatedById = Guid.NewGuid(),
                RoleId = 1,
                ManagerId = Guid.NewGuid()
            };

            var employee = new Domain.Entities.Employee("John", "Doe");
            var creator = new Domain.Entities.Employee("Admin", "User");
            var role = new Role(1, "Manager");

            _mapperMock.Setup(m => m.Map<CreateEmployeeCommand, Domain.Entities.Employee>(command)).Returns(employee);
            _validatorMock.Setup(v => v.Validate(employee)).Returns(new FluentValidation.Results.ValidationResult());
            _employeeRepositoryMock.Setup(r => r.GetByIdAsync(command.CreatedById)).ReturnsAsync(creator);
            _employeeRepositoryMock.Setup(r => r.GetRoleByIdAsync(command.RoleId)).ReturnsAsync(role);
            _employeeRepositoryMock.Setup(r => r.GetByIdAsync(command.ManagerId.Value)).ReturnsAsync((Domain.Entities.Employee)null);
            _rolePermissionServiceMock.Setup(r => r.CanCreateRoleAsync(It.IsAny<IEnumerable<Role>>(), It.IsAny<Role>())).ReturnsAsync(true);

            // Act
            var result = (await _employeeHandler.Handle(command)) as GenericCommandResult;

            // Assert
            Assert.IsFalse(result.Sucesss);
            Assert.AreEqual("Manager not found", result.Message);
        }
    }
}
