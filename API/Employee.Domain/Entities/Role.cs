using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee.Domain.Entities
{
    public class Role
    {
        public int RoleId { get; private set; }
        public string RoleName { get; private set; } = string.Empty;

        public IReadOnlyCollection<RolePermission> RolePermission => _rolePermission.AsReadOnly();

        private List<RolePermission>_rolePermission = new List<RolePermission>();

        private List<Employee>? _employee = new List<Employee>();

        public Role(int roleId, string roleName)
        {
            RoleId = roleId;
            RoleName = roleName;
        }

        public ICollection<Employee>? Employee => _employee.AsReadOnly();
    }
}
