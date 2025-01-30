using Employee.Domain.Entities;
using Employee.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee.Domain.Services
{
    public class RolePermissionService
    {
        private readonly IRolePermissionRepository _rolePermissionRepository;

        public RolePermissionService(IRolePermissionRepository rolePermissionRepository)
        {
            _rolePermissionRepository = rolePermissionRepository;
        }

        public virtual async Task<bool> CanCreateRoleAsync(IEnumerable<Role> creatorRoles, Role targetRole)
        {
            bool hasPermission = false;
            int i = 0;
            while (creatorRoles.Count() > 0 && creatorRoles.Count() <= i && hasPermission == false)
            {

                foreach (var item in creatorRoles.ElementAt(i).RolePermission)
                {
                    if (await this.CanCreateRoleAsync(item.Role, targetRole)){
                        hasPermission = true;
                        break;
                    }
                }

                i++;
            }

            return hasPermission;
        }

        public virtual async Task<bool> CanCreateRoleAsync(Role creatorRole, Role targetRole)
        {
            return await _rolePermissionRepository.CanCreateRoleAsync(creatorRole, targetRole);
        }
    }
}
