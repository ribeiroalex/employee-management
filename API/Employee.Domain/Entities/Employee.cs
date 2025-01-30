using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Employee.Domain.Entities.ValueObjects;
using Employee.Domain.Repositories;

namespace Employee.Domain.Entities
{
    public class Employee : Person
    {
        public Employee()
        {
                
        }

        public Employee(string firstName, string lastName)
            : base(firstName, lastName)
        {
        }

        public Employee(string firstName, string lastName, string documentNumber)
            : base(firstName, lastName)
        {
            SetDocumentNumber(documentNumber);
        }

        public void AddAddress(string addressLine)
        {
            AddAddressItem(addressLine);
        }

        public void AddPhone(string phoneNumber)
        {
            AddPhoneNumberItem(phoneNumber);
        }

        public void SetDocumentNumber(string documentNumber)
        {
            //Custom validation for the Employee document Number Rules.

            SetDocumentNumberValue(documentNumber);
        }


        public Guid? ManagerId { get; private set; }

        public Employee Manager { get; private set; }

        /// <summary>
        /// this action should have a domain service to center rules. but for simplicity of this demo we will keep it here.
        /// </summary>
        /// <param name="manager"></param>
        public void SetManager(Employee manager)
        {
            Manager = manager;
            ManagerId = manager.Id;
        }

        private List<Employee> _employessList = new List<Employee>();

        public IReadOnlyCollection<Employee> EmployessList => _employessList.AsReadOnly();

        private List<Role> _employeeRoles = new List<Role>();

        public IReadOnlyCollection<Role> Roles => _employeeRoles.AsReadOnly();
    }
}
