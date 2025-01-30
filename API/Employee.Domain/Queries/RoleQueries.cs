using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Employee.Domain.Queries
{
    public static class RoleQueries
    {
        public static Expression<Func<Entities.Role, bool>> GetById(int id)
        {
            return x => x.RoleId == id;
        }
    }
}
