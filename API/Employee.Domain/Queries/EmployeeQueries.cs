using System;
using System.Linq.Expressions;

namespace Employee.Domain.Queries
{
    public static class EmployeeQueries
    {
        public static Expression<Func<Entities.Employee, bool>> GetById(Guid id)
        {
            return x => x.Id == id;
        }
    }
}
