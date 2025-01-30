using Employee.Domain.Entities;
using Employee.Domain.Repositories;
using Emplyee.Infra.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emplyee.Infra.Repositories
{
    public class RolePermissionRepository : IRolePermissionRepository
    {
        private readonly DataContext _context;

        public RolePermissionRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<bool> CanCreateRoleAsync(Role creatorRole, Role targetRole)
        {
            return await _context.RolePermissions
                .AnyAsync(rp => rp.Role == creatorRole && rp.CanCreateRole == targetRole);
        }
    }
}
