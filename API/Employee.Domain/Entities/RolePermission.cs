using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee.Domain.Entities
{
    public  class RolePermission
    {

        public int RoleId { get; private set; }
        public Role Role { get; private set; }

        public int CanCreateRoleId { get; private set; }
        public Role CanCreateRole { get; private set; }

        public RolePermission() { }

        public RolePermission(Role role, Role canCreateRole)
        {
            Role = role;
            CanCreateRole = canCreateRole;
        }
    }
}
