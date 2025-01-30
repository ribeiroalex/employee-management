using Employee.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee.Domain.Repositories
{
    public interface IRolePermissionRepository
    {
        Task<bool> CanCreateRoleAsync(Role creatorRole, Role targetRole);
    }
}
