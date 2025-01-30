using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Employee.Domain.Entities.ValueObjects;

namespace Employee.Domain.Entities
{
    public abstract class Person : Entity
    {
        public Person()
        {
                
        }

        public Person(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }

        

        protected void AddPhoneNumberItem(string phoneNumber)
        {
            _phones.Add(new Phone(this.Id, phoneNumber));
        }
        protected void AddAddressItem(string addressLine)
        {
            _addresses.Add(new Address(this.Id, addressLine));
        }

        protected void RemoveAddressItem(string addressLine)
        {
            _addresses.Remove(new Address(this.Id, addressLine));
        }

        protected void RemovePhoneItem(string phoneNumber)
        {
            _phones.Remove(new Phone(this.Id, phoneNumber));
        }

        protected void SetDocumentNumberValue(string documentNumber)
        {
            DocumentNumber = documentNumber;
        }

        public string FirstName { get; private set; }

        public string LastName { get; private set; }

        public string DocumentNumber { get; private set; }

        public string Password { get; private set;}

        private List<Phone> _phones = new List<Phone>();
        private List<Address> _addresses = new List<Address>();

        public IReadOnlyCollection<Phone> Phones => _phones.AsReadOnly();

        public IReadOnlyCollection<Address> Addresses => _addresses.AsReadOnly();
    }
}
